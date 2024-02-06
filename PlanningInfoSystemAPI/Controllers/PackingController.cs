using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.Packing;
using PlanningInfoSystemAPI.Models.Pelleting;

namespace PlanningInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackingController : ControllerBase
    {
        private readonly DataContext _context;
        public PackingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Packing>>> GetPacking(string sortOrder = "asc")
        {
            var data = await _context.Packing.ToListAsync();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                data = data.OrderByDescending(x => x.Id).ToList();
            else
                data = data.OrderBy(x => x.Id).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Packing>> GetPackingById(int id)
        {
            var packing = await _context.Packing.FindAsync(id);

            if (packing == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product classification is not found.
            }

            return Ok(packing);
        }

        [HttpPost]
        public async Task<ActionResult<List<Packing>>> CreatePacking(Packing packing)
        {
            packing.CreatedDateTime = DateTime.Now;

            _context.Packing.Add(packing);
            await _context.SaveChangesAsync();

            // return Ok(await _context.Packing.ToListAsync());
            return Ok(new { Message = "Packing record created successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Packing>>> DeletePacking(int id)
        {
            var dbpacking = await _context.Packing.FindAsync(id);
            if (dbpacking == null)
                return BadRequest("Packing record not found.");

            _context.Packing.Remove(dbpacking);
            await _context.SaveChangesAsync();

            // return Ok(await _context.Packing.ToListAsync());
            return Ok(new { Message = "Packing record deleted successfully." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Packing>> UpdatePackingById(int id, [FromBody] Packing updatedData)
        {
            var existingData = await _context.Packing.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            // Update properties of existingData with values from updatedData
            existingData.ProdDate = updatedData.ProdDate;
            existingData.Feed_Run_No = updatedData.Feed_Run_No;
            existingData.Feed_Code = updatedData.Feed_Code;
            existingData.Feed_Name = updatedData.Feed_Name;
            existingData.Feed_ActualTons = updatedData.Feed_ActualTons;
            existingData.Feed_Forms = updatedData.Feed_Forms;
            existingData.Feed_BagWT = updatedData.Feed_BagWT;
            existingData.Product_PackStart = updatedData.Product_PackStart;
            existingData.Product_PackStop = updatedData.Product_PackStop;
            existingData.Product_TotalHours = updatedData.Product_TotalHours;
            existingData.Product_TonsHours = updatedData.Product_TonsHours;
            existingData.Product_STD = updatedData.Product_STD;
            existingData.Yield_ExpectedNoBags = updatedData.Yield_ExpectedNoBags;
            existingData.Yield_Completion = updatedData.Yield_Completion;
            existingData.Yield_RemainingTons = updatedData.Yield_RemainingTons;
            existingData.Yield_ActualBags = updatedData.Yield_ActualBags;
            existingData.Yield_SOKgs = updatedData.Yield_SOKgs;
            existingData.Yield_SBKgs = updatedData.Yield_SBKgs;
            existingData.Yield_RejectedBags = updatedData.Yield_RejectedBags;
            existingData.Yield_ActualYield = updatedData.Yield_ActualYield;
            existingData.Operator_Int = updatedData.Operator_Int;
            existingData.Operator_Shift = updatedData.Operator_Shift;
            existingData.Downtime_Hours = updatedData.Downtime_Hours;
            existingData.Downtime_Type = updatedData.Downtime_Type;
            existingData.Downtime_Accountability = updatedData.Downtime_Accountability;
            existingData.Downtime_Remarks = updatedData.Downtime_Remarks;
            existingData.LastModifiedDateTime = DateTime.Now;

            // Save changes to the database
            await _context.SaveChangesAsync();

            //return Ok(responseData);
            return Ok(new { Message = "Packing record updated successfully." });
        }
    }
}
