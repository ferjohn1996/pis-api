using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.Batching;

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

        [HttpGet]
        public async Task<ActionResult<List<Batching>>> GetBatching(string sortOrder = "asc")
        {
            var data = await _context.Batching.ToListAsync();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                data = data.OrderByDescending(x => x.Id).ToList();
            else
                data = data.OrderBy(x => x.Id).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Batching>> GetBatchingById(int id)
        {
            var batching = await _context.Batching.FindAsync(id);

            if (batching == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product classification is not found.
            }

            return Ok(batching);
        }

        [HttpPost]
        public async Task<ActionResult<List<Batching>>> CreateBatching(Batching batching)
        {
            batching.CreatedDateTime = DateTime.Now;

            _context.Batching.Add(batching);
            await _context.SaveChangesAsync();

            // return Ok(await _context.Batching.ToListAsync());
            return Ok(new { Message = "Batch record created successfully." });
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Batching>> UpdateBatching(int id, [FromBody] Batching updatedData)
        {
            var existingData = await _context.Batching.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            // Update properties of existingData with values from updatedData
            existingData.ProdDate = updatedData.ProdDate;
            existingData.ProdSchedule = updatedData.ProdSchedule;
            existingData.Run_No = updatedData.Run_No;
            existingData.Sub_Batch = updatedData.Sub_Batch;
            existingData.FeedCode = updatedData.FeedCode;
            existingData.Formula_Ver = updatedData.Formula_Ver;
            existingData.Formula_Date = updatedData.Formula_Date;
            existingData.FeedName = updatedData.FeedName;
            existingData.ActualTons = updatedData.ActualTons;
            existingData.Forms = updatedData.Forms;
            existingData.Setup_NoBatches = updatedData.Setup_NoBatches;
            existingData.Setup_BTC_Size = updatedData.Setup_BTC_Size;
            existingData.Setup_Feedrate_min = updatedData.Setup_Feedrate_min;
            existingData.Setup_Feedrate_max = updatedData.Setup_Feedrate_max;
            existingData.Setup_Motor_load = updatedData.Setup_Motor_load;
            existingData.Setup_H2O = updatedData.Setup_H2O;
            existingData.Setup_RPM = updatedData.Setup_RPM;
            existingData.HammerMill_screen1 = updatedData.HammerMill_screen1;
            existingData.HammerMill_screen2 = updatedData.HammerMill_screen2;
            existingData.MixProd_TimeStart = updatedData.MixProd_TimeStart;
            existingData.MixProd_TimeStop = updatedData.MixProd_TimeStop;
            existingData.MixProd_TotalHours = updatedData.MixProd_TotalHours;
            existingData.MixProd_TonsHours = updatedData.MixProd_TonsHours;
            existingData.MixProd_STD = updatedData.MixProd_STD;
            existingData.ReworkAdd_LotId = updatedData.ReworkAdd_LotId;
            existingData.ReworkAdd_Kilos = updatedData.ReworkAdd_Kilos;
            existingData.Bin_To = updatedData.Bin_To;
            existingData.ProdTeam_Optr = updatedData.ProdTeam_Optr;
            existingData.ProdTeam_ShiftVisor = updatedData.ProdTeam_ShiftVisor;
            existingData.ProdTeam_Dump1 = updatedData.ProdTeam_Dump1;
            existingData.ProdTeam_Dump2 = updatedData.ProdTeam_Dump2;
            existingData.ProdTeam_Dump3 = updatedData.ProdTeam_Dump3;
            existingData.Downtime_Hours = updatedData.Downtime_Hours;
            existingData.Downtime_Type = updatedData.Downtime_Type;
            existingData.Downtime_Accountability = updatedData.Downtime_Accountability;
            existingData.Downtime_Remarks = updatedData.Downtime_Remarks;
            existingData.LastModifiedDateTime = DateTime.Now;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO to return
            //var responseData = new Batching
            //{
            //    PlanningId = existingData.PlanningId,
            //    SKU = existingData.SKU,
            //    Description = existingData.Description,
            //    Form = existingData.Form,
            //    MT = existingData.MT,
            //    ActualHours = existingData.ActualHours,
            //    EffectiveCapacity = existingData.EffectiveCapacity,
            //    DieSizeThickness = existingData.DieSizeThickness,
            //    ChangeOver = existingData.ChangeOver,
            //    DowntimeGuide = existingData.DowntimeGuide,
            //    Accountability = existingData.Accountability,
            //    DelayStatus = existingData.DelayStatus,
            //    TimeProduce = existingData.TimeProduce,
            //    Remarks = existingData.Remarks
            //};
            //return Ok(responseData);
            return Ok(new { Message = "Batch record updated successfully." });
        }
    }
}
