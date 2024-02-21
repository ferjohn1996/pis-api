using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.Planning;

namespace PlanningInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningRequestController : ControllerBase
    {
        private readonly DataContext _context;

        public PlanningRequestController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<PlanningRequest>>> GetPlanningList()
        //{
        //    var data = await _context.PlanningRequest
        //    .Include(_ => _.Line1)
        //    .Include(_ => _.Line2)
        //    .Include(_ => _.Line3)
        //    .ToListAsync();


        //    return Ok(data);
        //}

        [HttpGet]
        public async Task<ActionResult<List<PlanningRequestResponseDTO>>> GetPlanningList(string sortOrder = "asc")
        {
            var data = await _context.PlanningRequest
                //.Include(_ => _.Line1)
                //.Include(_ => _.Line2)
                //.Include(_ => _.Line3)
                .ToListAsync();

            var response = data.Select(planning => new PlanningRequestDTO
            {
                Id = planning.Id,
                PlanningBatchId = planning.PlanningBatchId,
                Description = planning.Description,
                //Line1 = planning.Line1,
                //Line2 = planning.Line2,
                //Line3 = planning.Line3,
                CreatedDateTime = planning.CreatedDateTime,
                LastModifiedDateTime = planning.LastModifiedDateTime
            }).ToList();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                data = data.OrderByDescending(x => x.Id).ToList();
            else
                data = data.OrderBy(x => x.Id).ToList();

            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<PlanningRequest>>> GetPlanningListById(int id)
        //{
        //    var planning = await _context.PlanningRequest.FindAsync(id);

        //    return Ok(planning);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanningRequestDTO>> GetPlanningListById(int id)
        {
            var planning = await _context.PlanningRequest
                .Include(_ => _.Line1)
                .Include(_ => _.Line2)
                .Include(_ => _.Line3)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (planning == null)
            {
                return NotFound(); // Return 404 if planning request with the provided ID is not found
            }

            var response = new PlanningRequestDTO
            {
                Id = planning.Id,
                PlanningBatchId = planning.PlanningBatchId,
                Description = planning.Description,
                Line1 = planning.Line1,
                Line2 = planning.Line2,
                Line3 = planning.Line3,
                CreatedDateTime = planning.CreatedDateTime,
                LastModifiedDateTime = planning.LastModifiedDateTime
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PlanningRequestResponseDTO>> CreatePlanningRequest([FromBody] PlanningRequest data)
        {
            data.CreatedDateTime = DateTime.Now;

            // Determine the next available incrementing number for PlanningBatchId
            var nextBatchIdNumber = await _context.PlanningRequest.MaxAsync(pr => pr.Id) + 1;

            // Format the PlanningBatchId
            data.PlanningBatchId = $"PB-{nextBatchIdNumber:D5}"; // Assuming you want 5 digits with leading zeros


            _context.PlanningRequest.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new PlanningRequestResponseDTO
            {
                Id = data.Id,
                PlanningBatchId = data.PlanningBatchId,
                Description = data.Description,
                CreatedDateTime = data.CreatedDateTime,
                LastModifiedDateTime = data.LastModifiedDateTime
            };

            return Ok(responseData);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlanningRequestDTO>> UpdatePlanningRequest(int id, [FromBody] PlanningRequest updatedData)
        {
            var existingData = await _context.PlanningRequest
                .Include(p => p.Line1)
                .Include(p => p.Line2)
                .Include(p => p.Line3)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingData == null)
            {
                return NotFound(); // If the data with the provided ID doesn't exist
            }

            // Update only the allowed properties
            existingData.PlanningBatchId = updatedData.PlanningBatchId;
            existingData.Description = updatedData.Description;
            existingData.LastModifiedDateTime = DateTime.Now;

            // Update related entities
            existingData.Line1 = updatedData.Line1;
            existingData.Line2 = updatedData.Line2;
            existingData.Line3 = updatedData.Line3;

            // Mark properties as modified
            _context.Update(existingData);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle exception
                return StatusCode(500, "An error occurred while updating the entity.");
            }

            // Create DTO to return
            var responseData = new PlanningRequestDTO
            {
                Id = existingData.Id,
                PlanningBatchId = existingData.PlanningBatchId,
                Description = existingData.Description,
                Line1 = existingData.Line1,
                Line2 = existingData.Line2,
                Line3 = existingData.Line3,
                CreatedDateTime = existingData.CreatedDateTime,
                LastModifiedDateTime = existingData.LastModifiedDateTime
            };

            return Ok(responseData);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PlanningRequest>>> DeletePlanningRequest(int id)
        {
            var dbplanning = await _context.PlanningRequest.FindAsync(id);
            if (dbplanning == null)
                return BadRequest("Planning record not found.");

            _context.PlanningRequest.Remove(dbplanning);
            await _context.SaveChangesAsync();

            // return Ok(await _context.PlanningRequest.ToListAsync());
            return Ok(new { Message = "Planning record deleted successfully." });
        }

        [HttpPost]
        [Route("line1")]
        public async Task<ActionResult<PlanningRequestLine1DTO>> CreatePlanningLine1([FromBody] PlanningRequestLine1Tbl data)
        {
            // Assuming data.PlanningId is provided in the request body
            // Retrieve the corresponding PlanningRequest object from the database
            var parentPlanningRequest = await _context.PlanningRequest.FindAsync(data.PlanningId);

            if (parentPlanningRequest == null)
            {
                return BadRequest("Invalid PlanningId provided");
            }
            // Associate the child record with its parent
            data.Planning = parentPlanningRequest;


            _context.PlanningRequestLine1Tbl.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new PlanningRequestLine1DTO
            {
                PlanningId = data.PlanningId,
                SKU = data.SKU,
                Description = data.Description,
                Form = data.Form,
                MT = data.MT,
                ActualHours = data.ActualHours,
                EffectiveCapacity = data.EffectiveCapacity,
                DieSizeThickness = data.DieSizeThickness,
                ChangeOver = data.ChangeOver,
                Uncontrollable = data.Uncontrollable,
                Accountability = data.Accountability,
                DelayStatus = data.DelayStatus,
                TimeProduce = data.TimeProduce,
                Remarks = data.Remarks
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record added successfully.", Data = responseData });
        }

        //[HttpGet("line1/{id}")]
        //public async Task<ActionResult<PlanningRequestLine1DTO>> GetPlanningLine1(int id)
        //{
        //    var existingData = await _context.PlanningRequestLine1Tbl.FindAsync(id);

        //    if (existingData == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(existingData);
        //}

        [HttpPut("line1/{id}")]
        public async Task<ActionResult<PlanningRequestLine1DTO>> UpdatePlanningLine1(int id, [FromBody] PlanningRequestLine1Tbl updatedData)
        {
            var existingData = await _context.PlanningRequestLine1Tbl.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            // Update properties of existingData with values from updatedData
            existingData.SKU = updatedData.SKU;
            existingData.Description = updatedData.Description;
            existingData.Form = updatedData.Form;
            existingData.MT = updatedData.MT;
            existingData.ActualHours = updatedData.ActualHours;
            existingData.EffectiveCapacity = updatedData.EffectiveCapacity;
            existingData.DieSizeThickness = updatedData.DieSizeThickness;
            existingData.ChangeOver = updatedData.ChangeOver;
            existingData.Uncontrollable = updatedData.Uncontrollable;
            existingData.Accountability = updatedData.Accountability;
            existingData.DelayStatus = updatedData.DelayStatus;
            existingData.TimeProduce = updatedData.TimeProduce;
            existingData.Remarks = updatedData.Remarks;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO to return
            var responseData = new PlanningRequestLine1DTO
            {
                PlanningId = existingData.PlanningId,
                SKU = existingData.SKU,
                Description = existingData.Description,
                Form = existingData.Form,
                MT = existingData.MT,
                ActualHours = existingData.ActualHours,
                EffectiveCapacity = existingData.EffectiveCapacity,
                DieSizeThickness = existingData.DieSizeThickness,
                ChangeOver = existingData.ChangeOver,
                Uncontrollable = existingData.Uncontrollable,
                Accountability = existingData.Accountability,
                DelayStatus = existingData.DelayStatus,
                TimeProduce = existingData.TimeProduce,
                Remarks = existingData.Remarks
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record updated successfully.", Data = responseData });
        }

        [HttpDelete("line1/{id}")]
        public async Task<ActionResult<List<PlanningRequestLine1Tbl>>> DeletePlanningLine1(int id)
        {
            var data = await _context.PlanningRequestLine1Tbl.FindAsync(id);
            if (data == null)
                return BadRequest("Downtime not found.");

            _context.PlanningRequestLine1Tbl.Remove(data);
            await _context.SaveChangesAsync();
            //return Ok(await _context.PlanningRequestLine1Tbl.ToListAsync());
            return Ok(new { Message = "Record deleted successfully."});
        }

        [HttpPost]
        [Route("line2")]
        public async Task<ActionResult<PlanningRequestLine2DTO>> CreatePlanningLine2([FromBody] PlanningRequestLine2Tbl data)
        {
            // Assuming data.PlanningId is provided in the request body
            // Retrieve the corresponding PlanningRequest object from the database
            var parentPlanningRequest = await _context.PlanningRequest.FindAsync(data.PlanningId);

            if (parentPlanningRequest == null)
            {
                return BadRequest("Invalid PlanningId provided");
            }
            // Associate the child record with its parent
            data.Planning = parentPlanningRequest;


            _context.PlanningRequestLine2Tbl.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new PlanningRequestLine2DTO
            {
                PlanningId = data.PlanningId,
                SKU = data.SKU,
                Description = data.Description,
                Form = data.Form,
                MT = data.MT,
                ActualHours = data.ActualHours,
                EffectiveCapacity = data.EffectiveCapacity,
                DieSizeThickness = data.DieSizeThickness,
                ChangeOver = data.ChangeOver,
                Uncontrollable = data.Uncontrollable,
                Accountability = data.Accountability,
                DelayStatus = data.DelayStatus,
                TimeProduce = data.TimeProduce,
                Remarks = data.Remarks
            };
            //return Ok(responseData);
            return Ok(new { Message = "Record added successfully.", Data = responseData });
        }

        [HttpPut("line2/{id}")]
        public async Task<ActionResult<PlanningRequestLine2DTO>> UpdatePlanningLine2(int id, [FromBody] PlanningRequestLine2Tbl updatedData)
        {
            var existingData = await _context.PlanningRequestLine2Tbl.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            // Update properties of existingData with values from updatedData
            existingData.SKU = updatedData.SKU;
            existingData.Description = updatedData.Description;
            existingData.Form = updatedData.Form;
            existingData.MT = updatedData.MT;
            existingData.ActualHours = updatedData.ActualHours;
            existingData.EffectiveCapacity = updatedData.EffectiveCapacity;
            existingData.DieSizeThickness = updatedData.DieSizeThickness;
            existingData.ChangeOver = updatedData.ChangeOver;
            existingData.Uncontrollable = updatedData.Uncontrollable;
            existingData.Accountability = updatedData.Accountability;
            existingData.DelayStatus = updatedData.DelayStatus;
            existingData.TimeProduce = updatedData.TimeProduce;
            existingData.Remarks = updatedData.Remarks;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO to return
            var responseData = new PlanningRequestLine2DTO
            {
                PlanningId = existingData.PlanningId,
                SKU = existingData.SKU,
                Description = existingData.Description,
                Form = existingData.Form,
                MT = existingData.MT,
                ActualHours = existingData.ActualHours,
                EffectiveCapacity = existingData.EffectiveCapacity,
                DieSizeThickness = existingData.DieSizeThickness,
                ChangeOver = existingData.ChangeOver,
                Uncontrollable = existingData.Uncontrollable,
                Accountability = existingData.Accountability,
                DelayStatus = existingData.DelayStatus,
                TimeProduce = existingData.TimeProduce,
                Remarks = existingData.Remarks
            };

            // return Ok(responseData);
            return Ok(new { Message = "Record updated successfully.", Data = responseData });
        }

        [HttpDelete("line2/{id}")]
        public async Task<ActionResult<List<PlanningRequestLine2Tbl>>> DeletePlanningLine2(int id)
        {
            var data = await _context.PlanningRequestLine2Tbl.FindAsync(id);
            if (data == null)
                return BadRequest("Downtime not found.");

            _context.PlanningRequestLine2Tbl.Remove(data);
            await _context.SaveChangesAsync();

            // return Ok(await _context.PlanningRequestLine2Tbl.ToListAsync());
            return Ok(new { Message = "Record deleted successfully." });
        }

        [HttpPost]
        [Route("line3")]
        public async Task<ActionResult<PlanningRequestLine3DTO>> CreatePlanningLine3([FromBody] PlanningRequestLine3Tbl data)
        {
            // Assuming data.PlanningId is provided in the request body
            // Retrieve the corresponding PlanningRequest object from the database
            var parentPlanningRequest = await _context.PlanningRequest.FindAsync(data.PlanningId);

            if (parentPlanningRequest == null)
            {
                return BadRequest("Invalid PlanningId provided");
            }
            // Associate the child record with its parent
            data.Planning = parentPlanningRequest;


            _context.PlanningRequestLine3Tbl.Add(data);
            await _context.SaveChangesAsync();

            var responseData = new PlanningRequestLine3DTO
            {
                PlanningId = data.PlanningId,
                SKU = data.SKU,
                Description = data.Description,
                Form = data.Form,
                MT = data.MT,
                ActualHours = data.ActualHours,
                EffectiveCapacity = data.EffectiveCapacity,
                DieSizeThickness = data.DieSizeThickness,
                ChangeOver = data.ChangeOver,
                Uncontrollable = data.Uncontrollable,
                Accountability = data.Accountability,
                DelayStatus = data.DelayStatus,
                TimeProduce = data.TimeProduce,
                Remarks = data.Remarks
            };
            return Ok(new { Message = "Record added successfully.", Data = responseData });
        }

        [HttpPut("line3/{id}")]
        public async Task<ActionResult<PlanningRequestLine3DTO>> UpdatePlanningLine3(int id, [FromBody] PlanningRequestLine3Tbl updatedData)
        {
            var existingData = await _context.PlanningRequestLine3Tbl.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            // Update properties of existingData with values from updatedData
            existingData.SKU = updatedData.SKU;
            existingData.Description = updatedData.Description;
            existingData.Form = updatedData.Form;
            existingData.MT = updatedData.MT;
            existingData.ActualHours = updatedData.ActualHours;
            existingData.EffectiveCapacity = updatedData.EffectiveCapacity;
            existingData.DieSizeThickness = updatedData.DieSizeThickness;
            existingData.ChangeOver = updatedData.ChangeOver;
            existingData.Uncontrollable = updatedData.Uncontrollable;
            existingData.Accountability = updatedData.Accountability;
            existingData.DelayStatus = updatedData.DelayStatus;
            existingData.TimeProduce = updatedData.TimeProduce;
            existingData.Remarks = updatedData.Remarks;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO to return
            var responseData = new PlanningRequestLine3DTO
            {
                PlanningId = existingData.PlanningId,
                SKU = existingData.SKU,
                Description = existingData.Description,
                Form = existingData.Form,
                MT = existingData.MT,
                ActualHours = existingData.ActualHours,
                EffectiveCapacity = existingData.EffectiveCapacity,
                DieSizeThickness = existingData.DieSizeThickness,
                ChangeOver = existingData.ChangeOver,
                Uncontrollable = existingData.Uncontrollable,
                Accountability = existingData.Accountability,
                DelayStatus = existingData.DelayStatus,
                TimeProduce = existingData.TimeProduce,
                Remarks = existingData.Remarks
            };

            //return Ok(responseData);
            return Ok(new { Message = "Record updated successfully.", Data = responseData });
        }

        [HttpDelete("line3/{id}")]
        public async Task<ActionResult<List<PlanningRequestLine3Tbl>>> DeletePlanningLine3(int id)
        {
            var data = await _context.PlanningRequestLine3Tbl.FindAsync(id);
            if (data == null)
                return BadRequest("Downtime not found.");

            _context.PlanningRequestLine3Tbl.Remove(data);
            await _context.SaveChangesAsync();
            // return Ok(await _context.PlanningRequestLine3Tbl.ToListAsync());
            // return Ok(new { Message = "Downtime deleted successfully.", RemainingRecords = await _context.PlanningRequestLine3Tbl.ToListAsync() });
            return Ok(new { Message = "Record deleted successfully." });
        }
    }
}
