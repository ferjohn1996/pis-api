using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.Batching;
using PlanningInfoSystemAPI.Models.Planning;

namespace PlanningInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchingController : ControllerBase
    {
        private readonly DataContext _context;

        public BatchingController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Batching>>> GetBatching(string sortOrder = "asc")
        //{
        //    var data = await _context.Batching.ToListAsync();

        //    // Sort the data based on sortOrder
        //    if (sortOrder.ToLower() == "desc")
        //        data = data.OrderByDescending(x => x.Id).ToList();
        //    else
        //        data = data.OrderBy(x => x.Id).ToList();

        //    return Ok(data);
        //}

        [HttpGet]
        public async Task<ActionResult<List<BatchingResponseDTO>>> GetBatchingList(string sortOrder = "asc")
        {
            var query = _context.Batching.AsQueryable();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                query = query.OrderByDescending(x => x.Id);
            else
                query = query.OrderBy(x => x.Id);

            var data = await query.ToListAsync();

            var response = data.Select(batch => new BatchingDTO
            {
                Id = batch.Id,
                BatchingId = batch.BatchingId,
                Description = batch.Description,
                statusId = batch.statusId,
                CreatedDateTime = batch.CreatedDateTime,
                LastModifiedDateTime = batch.LastModifiedDateTime
            }).ToList();

            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Batching>> GetBatchingById(int id)
        //{
        //    var batching = await _context.Batching.FindAsync(id);

        //    if (batching == null)
        //    {
        //        return NotFound(); // Return a 404 Not Found response if the product classification is not found.
        //    }

        //    return Ok(batching);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchingDTO>> GetBatchingListById(int id)
        {
            var batch = await _context.Batching
            .Include(pr => pr.Batch1)
            .Include(pr => pr.Batch2)
            .FirstOrDefaultAsync(x => x.Id == id);

            if (batch == null)
            {
                return NotFound(); // Return 404 if planning request with the provided ID is not found
            }

            var response = new BatchingDTO
            {
                Id = batch.Id,
                BatchingId = batch.BatchingId,
                Description = batch.Description,
                statusId = batch.statusId,
                Batch1 = batch.Batch1,
                Batch2 = batch.Batch2,
                CreatedDateTime = batch.CreatedDateTime,
                LastModifiedDateTime = batch.LastModifiedDateTime
            };

            return Ok(response);
        }

        //[HttpPost]
        //public async Task<ActionResult<List<Batching>>> CreateBatching(Batching batching)
        //{
        //    batching.CreatedDateTime = DateTime.Now;

        //    _context.Batching.Add(batching);
        //    await _context.SaveChangesAsync();

        //    // return Ok(await _context.Batching.ToListAsync());
        //    return Ok(new { Message = "Batch record created successfully." });
        //}

        [HttpPost]
        public async Task<ActionResult<BatchingResponseDTO>> CreateBatching([FromBody] Batching data)
        {
            data.CreatedDateTime = DateTime.Now;

            // Check if there are any records in the PlanningRequest table
            var hasRecords = await _context.Batching.AnyAsync();

            // Determine the next available incrementing number for PlanningBatchId
            var nextBatchIdNumber = hasRecords ? await _context.Batching.MaxAsync(pr => pr.Id) + 1 : 1;

            // Format the BatchId
            data.BatchingId = $"PB-{nextBatchIdNumber:D5}"; // Assuming you want 5 digits with leading zeros


            _context.Batching.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new BatchingResponseDTO
            {
                Id = data.Id,
                BatchingId = data.BatchingId,
                Description = data.Description,
                CreatedDateTime = data.CreatedDateTime,
                LastModifiedDateTime = data.LastModifiedDateTime
            };

            return Ok(responseData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Batching>>> DeleteBatching(int id)
        {
            var dbbatching = await _context.Batching.FindAsync(id);
            if (dbbatching == null)
                return BadRequest("Batch record not found.");

            _context.Batching.Remove(dbbatching);
            await _context.SaveChangesAsync();

            // return Ok(await _context.Batching.ToListAsync());
            return Ok(new { Message = "Batch record deleted successfully." });
        }

        [HttpPost]
        [Route("batch1")]
        public async Task<ActionResult<Batching1DTO>> CreateBatching1([FromBody] Batching1 data)
        {
            data.CreatedDateTime = DateTime.Now;

            // Assuming data.BatchId is provided in the request body
            // Retrieve the corresponding Batching object from the database
            var parentBatching = await _context.Batching.FindAsync(data.BatchId);

            if (parentBatching == null)
            {
                return BadRequest("Invalid BatchId provided");
            }
            // Associate the child record with its parent
            data.BatchId = parentBatching.Id;

            // Add the child record to the parent's collection
            parentBatching.Batch1.Add(data);

            _context.Batching1.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new Batching1DTO
            {
                BatchId = data.BatchId,
                ProdDate = data.ProdDate,
                ProdSchedule = data.ProdSchedule,
                Run_No = data.Run_No,
                Sub_Batch = data.Sub_Batch,
                FeedCode = data.FeedCode,
                Formula_Ver = data.Formula_Ver,
                Formula_Date = data.Formula_Date,
                FeedName = data.FeedName,
                ActualTons = data.ActualTons,
                Forms = data.Forms,
                Setup_NoBatches = data.Setup_NoBatches,
                Setup_BTC_Size = data.Setup_BTC_Size,
                Setup_Feedrate_min = data.Setup_Feedrate_min,
                Setup_Feedrate_max = data.Setup_Feedrate_max,
                Setup_Motor_load = data.Setup_Motor_load,
                Setup_H2O = data.Setup_H2O,
                Setup_RPM = data.Setup_RPM,
                HammerMill_screen1 = data.HammerMill_screen1,
                HammerMill_screen2 = data.HammerMill_screen2,
                MixProd_TimeStart = data.MixProd_TimeStart,
                MixProd_TimeStop = data.MixProd_TimeStop,
                MixProd_TotalHours = data.MixProd_TotalHours,
                MixProd_TonsHours = data.MixProd_TonsHours,
                MixProd_STD = data.MixProd_STD,
                ReworkAdd_LotId = data.ReworkAdd_LotId,
                ReworkAdd_Kilos = data.ReworkAdd_Kilos,
                Bin_To = data.Bin_To,
                ProdTeam_Optr = data.ProdTeam_Optr,
                ProdTeam_ShiftVisor = data.ProdTeam_ShiftVisor,
                ProdTeam_Dump1 = data.ProdTeam_Dump1,
                ProdTeam_Dump2 = data.ProdTeam_Dump2,
                ProdTeam_Dump3 = data.ProdTeam_Dump3,
                Downtime_Hours = data.Downtime_Hours,
                Downtime_Type = data.Downtime_Type,
                Downtime_Accountability = data.Downtime_Accountability,
                Downtime_Remarks = data.Downtime_Remarks,
                CreatedDateTime = data.CreatedDateTime,
                LastModifiedDateTime = data.LastModifiedDateTime
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record added successfully.", Data = responseData });
        }

        [HttpGet("batch1/{id}")]
        public async Task<ActionResult<Batching1>> GetBatching1(int id)
        {
            var existingData = await _context.Batching1.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            return Ok(existingData);
        }

        [HttpPut("batch1/{id}")]
        public async Task<ActionResult<Batching1DTO>> UpdateBatching1(int id, [FromBody] Batching1 data)
        {
            data.LastModifiedDateTime = DateTime.Now;

            var existingData = await _context.Batching1.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            //existingData.BatchId = data.BatchId;
            existingData.ProdDate = data.ProdDate;
            existingData.ProdSchedule = data.ProdSchedule;
            existingData.Run_No = data.Run_No;
            existingData.Sub_Batch = data.Sub_Batch;
            existingData.FeedCode = data.FeedCode;
            existingData.Formula_Ver = data.Formula_Ver;
            existingData.Formula_Date = data.Formula_Date;
            existingData.FeedName = data.FeedName;
            existingData.ActualTons = data.ActualTons;
            existingData.Forms = data.Forms;
            existingData.Setup_NoBatches = data.Setup_NoBatches;
            existingData.Setup_BTC_Size = data.Setup_BTC_Size;
            existingData.Setup_Feedrate_min = data.Setup_Feedrate_min;
            existingData.Setup_Feedrate_max = data.Setup_Feedrate_max;
            existingData.Setup_Motor_load = data.Setup_Motor_load;
            existingData.Setup_H2O = data.Setup_H2O;
            existingData.Setup_RPM = data.Setup_RPM;
            existingData.HammerMill_screen1 = data.HammerMill_screen1;
            existingData.HammerMill_screen2 = data.HammerMill_screen2;
            existingData.MixProd_TimeStart = data.MixProd_TimeStart;
            existingData.MixProd_TimeStop = data.MixProd_TimeStop;
            existingData.MixProd_TotalHours = data.MixProd_TotalHours;
            existingData.MixProd_TonsHours = data.MixProd_TonsHours;
            existingData.MixProd_STD = data.MixProd_STD;
            existingData.ReworkAdd_LotId = data.ReworkAdd_LotId;
            existingData.ReworkAdd_Kilos = data.ReworkAdd_Kilos;
            existingData.Bin_To = data.Bin_To;
            existingData.ProdTeam_Optr = data.ProdTeam_Optr;
            existingData.ProdTeam_ShiftVisor = data.ProdTeam_ShiftVisor;
            existingData.ProdTeam_Dump1 = data.ProdTeam_Dump1;
            existingData.ProdTeam_Dump2 = data.ProdTeam_Dump2;
            existingData.ProdTeam_Dump3 = data.ProdTeam_Dump3;
            existingData.Downtime_Hours = data.Downtime_Hours;
            existingData.Downtime_Type = data.Downtime_Type;
            existingData.Downtime_Accountability = data.Downtime_Accountability;
            existingData.Downtime_Remarks = data.Downtime_Remarks;
            existingData.CreatedDateTime = data.CreatedDateTime;
            existingData.LastModifiedDateTime = data.LastModifiedDateTime;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO to return
            var responseData = new Batching1DTO
            {
                BatchId = existingData.BatchId,
                ProdDate = existingData.ProdDate,
                ProdSchedule = existingData.ProdSchedule,
                Run_No = existingData.Run_No,
                Sub_Batch = existingData.Sub_Batch,
                FeedCode = existingData.FeedCode,
                Formula_Ver = existingData.Formula_Ver,
                Formula_Date = existingData.Formula_Date,
                FeedName = existingData.FeedName,
                ActualTons = existingData.ActualTons,
                Forms = existingData.Forms,
                Setup_NoBatches = existingData.Setup_NoBatches,
                Setup_BTC_Size = existingData.Setup_BTC_Size,
                Setup_Feedrate_min = existingData.Setup_Feedrate_min,
                Setup_Feedrate_max = existingData.Setup_Feedrate_max,
                Setup_Motor_load = existingData.Setup_Motor_load,
                Setup_H2O = existingData.Setup_H2O,
                Setup_RPM = existingData.Setup_RPM,
                HammerMill_screen1 = existingData.HammerMill_screen1,
                HammerMill_screen2 = existingData.HammerMill_screen2,
                MixProd_TimeStart = existingData.MixProd_TimeStart,
                MixProd_TimeStop = existingData.MixProd_TimeStop,
                MixProd_TotalHours = existingData.MixProd_TotalHours,
                MixProd_TonsHours = existingData.MixProd_TonsHours,
                MixProd_STD = existingData.MixProd_STD,
                ReworkAdd_LotId = existingData.ReworkAdd_LotId,
                ReworkAdd_Kilos = existingData.ReworkAdd_Kilos,
                Bin_To = existingData.Bin_To,
                ProdTeam_Optr = existingData.ProdTeam_Optr,
                ProdTeam_ShiftVisor = existingData.ProdTeam_ShiftVisor,
                ProdTeam_Dump1 = existingData.ProdTeam_Dump1,
                ProdTeam_Dump2 = existingData.ProdTeam_Dump2,
                ProdTeam_Dump3 = existingData.ProdTeam_Dump3,
                Downtime_Hours = existingData.Downtime_Hours,
                Downtime_Type = existingData.Downtime_Type,
                Downtime_Accountability = existingData.Downtime_Accountability,
                Downtime_Remarks = existingData.Downtime_Remarks,
                CreatedDateTime = existingData.CreatedDateTime,
                LastModifiedDateTime = existingData.LastModifiedDateTime
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record updated successfully.", Data = responseData });
        }

        [HttpDelete("batch1/{id}")]
        public async Task<ActionResult<List<Batching1>>> DeleteBatching1(int id)
        {
            var data = await _context.Batching1.FindAsync(id);
            if (data == null)
                return BadRequest("Batch not found.");

            _context.Batching1.Remove(data);
            await _context.SaveChangesAsync();
            //return Ok(await _context.Batching1.ToListAsync());
            return Ok(new { Message = "Record deleted successfully." });
        }

        [HttpPost]
        [Route("batch2")]
        public async Task<ActionResult<Batching2DTO>> CreateBatching2([FromBody] Batching2 data)
        {
            data.CreatedDateTime = DateTime.Now;

            // Assuming data.BatchId is provided in the request body
            // Retrieve the corresponding Batching object from the database
            var parentBatching = await _context.Batching.FindAsync(data.BatchId);

            if (parentBatching == null)
            {
                return BadRequest("Invalid BatchId provided");
            }
            // Associate the child record with its parent
            data.BatchId = parentBatching.Id;

            // Add the child record to the parent's collection
            parentBatching.Batch2.Add(data);

            _context.Batching2.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new Batching2DTO
            {
                BatchId = data.BatchId,
                ProdDate = data.ProdDate,
                ProdSchedule = data.ProdSchedule,
                Run_No = data.Run_No,
                Sub_Batch = data.Sub_Batch,
                FeedCode = data.FeedCode,
                Formula_Ver = data.Formula_Ver,
                Formula_Date = data.Formula_Date,
                FeedName = data.FeedName,
                ActualTons = data.ActualTons,
                Forms = data.Forms,
                Setup_NoBatches = data.Setup_NoBatches,
                Setup_BTC_Size = data.Setup_BTC_Size,
                Setup_Feedrate_min = data.Setup_Feedrate_min,
                Setup_Feedrate_max = data.Setup_Feedrate_max,
                Setup_Motor_load = data.Setup_Motor_load,
                Setup_H2O = data.Setup_H2O,
                Setup_RPM = data.Setup_RPM,
                HammerMill_screen1 = data.HammerMill_screen1,
                HammerMill_screen2 = data.HammerMill_screen2,
                MixProd_TimeStart = data.MixProd_TimeStart,
                MixProd_TimeStop = data.MixProd_TimeStop,
                MixProd_TotalHours = data.MixProd_TotalHours,
                MixProd_TonsHours = data.MixProd_TonsHours,
                MixProd_STD = data.MixProd_STD,
                ReworkAdd_LotId = data.ReworkAdd_LotId,
                ReworkAdd_Kilos = data.ReworkAdd_Kilos,
                Bin_To = data.Bin_To,
                ProdTeam_Optr = data.ProdTeam_Optr,
                ProdTeam_ShiftVisor = data.ProdTeam_ShiftVisor,
                ProdTeam_Dump1 = data.ProdTeam_Dump1,
                ProdTeam_Dump2 = data.ProdTeam_Dump2,
                ProdTeam_Dump3 = data.ProdTeam_Dump3,
                Downtime_Hours = data.Downtime_Hours,
                Downtime_Type = data.Downtime_Type,
                Downtime_Accountability = data.Downtime_Accountability,
                Downtime_Remarks = data.Downtime_Remarks,
                CreatedDateTime = data.CreatedDateTime,
                LastModifiedDateTime = data.LastModifiedDateTime
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record added successfully.", Data = responseData });
        }

        [HttpGet("batch2/{id}")]
        public async Task<ActionResult<Batching2>> GetBatching2(int id)
        {
            var existingData = await _context.Batching2.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            return Ok(existingData);
        }

        [HttpPut("batch2/{id}")]
        public async Task<ActionResult<Batching2DTO>> UpdateBatching2(int id, [FromBody] Batching2 data)
        {
            data.LastModifiedDateTime = DateTime.Now;

            var existingData = await _context.Batching2.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            //existingData.BatchId = data.BatchId;
            existingData.ProdDate = data.ProdDate;
            existingData.ProdSchedule = data.ProdSchedule;
            existingData.Run_No = data.Run_No;
            existingData.Sub_Batch = data.Sub_Batch;
            existingData.FeedCode = data.FeedCode;
            existingData.Formula_Ver = data.Formula_Ver;
            existingData.Formula_Date = data.Formula_Date;
            existingData.FeedName = data.FeedName;
            existingData.ActualTons = data.ActualTons;
            existingData.Forms = data.Forms;
            existingData.Setup_NoBatches = data.Setup_NoBatches;
            existingData.Setup_BTC_Size = data.Setup_BTC_Size;
            existingData.Setup_Feedrate_min = data.Setup_Feedrate_min;
            existingData.Setup_Feedrate_max = data.Setup_Feedrate_max;
            existingData.Setup_Motor_load = data.Setup_Motor_load;
            existingData.Setup_H2O = data.Setup_H2O;
            existingData.Setup_RPM = data.Setup_RPM;
            existingData.HammerMill_screen1 = data.HammerMill_screen1;
            existingData.HammerMill_screen2 = data.HammerMill_screen2;
            existingData.MixProd_TimeStart = data.MixProd_TimeStart;
            existingData.MixProd_TimeStop = data.MixProd_TimeStop;
            existingData.MixProd_TotalHours = data.MixProd_TotalHours;
            existingData.MixProd_TonsHours = data.MixProd_TonsHours;
            existingData.MixProd_STD = data.MixProd_STD;
            existingData.ReworkAdd_LotId = data.ReworkAdd_LotId;
            existingData.ReworkAdd_Kilos = data.ReworkAdd_Kilos;
            existingData.Bin_To = data.Bin_To;
            existingData.ProdTeam_Optr = data.ProdTeam_Optr;
            existingData.ProdTeam_ShiftVisor = data.ProdTeam_ShiftVisor;
            existingData.ProdTeam_Dump1 = data.ProdTeam_Dump1;
            existingData.ProdTeam_Dump2 = data.ProdTeam_Dump2;
            existingData.ProdTeam_Dump3 = data.ProdTeam_Dump3;
            existingData.Downtime_Hours = data.Downtime_Hours;
            existingData.Downtime_Type = data.Downtime_Type;
            existingData.Downtime_Accountability = data.Downtime_Accountability;
            existingData.Downtime_Remarks = data.Downtime_Remarks;
            existingData.CreatedDateTime = data.CreatedDateTime;
            existingData.LastModifiedDateTime = data.LastModifiedDateTime;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO to return
            var responseData = new Batching2DTO
            {
                BatchId = existingData.BatchId,
                ProdDate = existingData.ProdDate,
                ProdSchedule = existingData.ProdSchedule,
                Run_No = existingData.Run_No,
                Sub_Batch = existingData.Sub_Batch,
                FeedCode = existingData.FeedCode,
                Formula_Ver = existingData.Formula_Ver,
                Formula_Date = existingData.Formula_Date,
                FeedName = existingData.FeedName,
                ActualTons = existingData.ActualTons,
                Forms = existingData.Forms,
                Setup_NoBatches = existingData.Setup_NoBatches,
                Setup_BTC_Size = existingData.Setup_BTC_Size,
                Setup_Feedrate_min = existingData.Setup_Feedrate_min,
                Setup_Feedrate_max = existingData.Setup_Feedrate_max,
                Setup_Motor_load = existingData.Setup_Motor_load,
                Setup_H2O = existingData.Setup_H2O,
                Setup_RPM = existingData.Setup_RPM,
                HammerMill_screen1 = existingData.HammerMill_screen1,
                HammerMill_screen2 = existingData.HammerMill_screen2,
                MixProd_TimeStart = existingData.MixProd_TimeStart,
                MixProd_TimeStop = existingData.MixProd_TimeStop,
                MixProd_TotalHours = existingData.MixProd_TotalHours,
                MixProd_TonsHours = existingData.MixProd_TonsHours,
                MixProd_STD = existingData.MixProd_STD,
                ReworkAdd_LotId = existingData.ReworkAdd_LotId,
                ReworkAdd_Kilos = existingData.ReworkAdd_Kilos,
                Bin_To = existingData.Bin_To,
                ProdTeam_Optr = existingData.ProdTeam_Optr,
                ProdTeam_ShiftVisor = existingData.ProdTeam_ShiftVisor,
                ProdTeam_Dump1 = existingData.ProdTeam_Dump1,
                ProdTeam_Dump2 = existingData.ProdTeam_Dump2,
                ProdTeam_Dump3 = existingData.ProdTeam_Dump3,
                Downtime_Hours = existingData.Downtime_Hours,
                Downtime_Type = existingData.Downtime_Type,
                Downtime_Accountability = existingData.Downtime_Accountability,
                Downtime_Remarks = existingData.Downtime_Remarks,
                CreatedDateTime = existingData.CreatedDateTime,
                LastModifiedDateTime = existingData.LastModifiedDateTime
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record updated successfully.", Data = responseData });
        }

        [HttpDelete("batch2/{id}")]
        public async Task<ActionResult<List<Batching2>>> DeleteBatching2(int id)
        {
            var data = await _context.Batching2.FindAsync(id);
            if (data == null)
                return BadRequest("Batch not found.");

            _context.Batching2.Remove(data);
            await _context.SaveChangesAsync();
            //return Ok(await _context.Batching2.ToListAsync());
            return Ok(new { Message = "Record deleted successfully." });
        }
    }
}
