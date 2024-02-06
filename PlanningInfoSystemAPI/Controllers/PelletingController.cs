using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.Batching;
using PlanningInfoSystemAPI.Models.Pelleting;

namespace PlanningInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PelletingController : ControllerBase
    {
        private readonly DataContext _context;
        public PelletingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pelleting>>> GetPelleting(string sortOrder = "asc")
        {
            var data = await _context.Pelleting.ToListAsync();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                data = data.OrderByDescending(x => x.Id).ToList();
            else
                data = data.OrderBy(x => x.Id).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelleting>> GetPelletingById(int id)
        {
            var pelleting = await _context.Pelleting.FindAsync(id);

            if (pelleting == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product classification is not found.
            }

            return Ok(pelleting);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pelleting>>> CreatePelleting(Pelleting pelleting)
        {
            pelleting.CreatedDateTime = DateTime.Now;

            _context.Pelleting.Add(pelleting);
            await _context.SaveChangesAsync();

            // return Ok(await _context.Pelleting.ToListAsync());
            return Ok(new { Message = "Pelleting record created successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Pelleting>>> DeletePelleting(int id)
        {
            var dbpelleting = await _context.Pelleting.FindAsync(id);
            if (dbpelleting == null)
                return BadRequest("Pellet record not found.");

            _context.Pelleting.Remove(dbpelleting);
            await _context.SaveChangesAsync();

            // return Ok(await _context.Pelleting.ToListAsync());
            return Ok(new { Message = "Pellet record deleted successfully." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pelleting>> UpdatePelletingById(int id, [FromBody] Pelleting updatedData)
        {
            var existingData = await _context.Pelleting.FindAsync(id);

            if (existingData == null)
            {
                return NotFound();
            }

            // Update properties of existingData with values from updatedData
            existingData.ProdDate = updatedData.ProdDate;
            existingData.Feed_Run_No = updatedData.Feed_Run_No;
            existingData.Feed_Code = updatedData.Feed_Code;
            existingData.Feed_Name_Medication = updatedData.Feed_Name_Medication;
            existingData.Feed_Actual_Tons = updatedData.Feed_Actual_Tons;
            existingData.Feed_Forms = updatedData.Feed_Forms;
            existingData.Feed_Bin_Mash = updatedData.Feed_Bin_Mash;
            existingData.Feed_Bin_Ff = updatedData.Feed_Bin_Ff;
            existingData.Feed_Optr_Init = updatedData.Feed_Optr_Init;
            existingData.Feed_Optr_Visor = updatedData.Feed_Optr_Visor;
            existingData.Pellet_Start = updatedData.Pellet_Start;
            existingData.Pellet_Stop = updatedData.Pellet_Stop;
            existingData.Pellet_Total_Hours = updatedData.Pellet_Total_Hours;
            existingData.Pellet_Tons_TPH = updatedData.Pellet_Tons_TPH;
            existingData.Pellet_STD = updatedData.Pellet_STD;
            existingData.Mill_Feeder_Setting = updatedData.Mill_Feeder_Setting;
            existingData.Mill_Steam_Setpoint = updatedData.Mill_Steam_Setpoint;
            existingData.Mill_Steam_PSI = updatedData.Mill_Steam_PSI;
            existingData.Mill_Ret_Team = updatedData.Mill_Ret_Team;
            existingData.Mill_Amps_Load = updatedData.Mill_Amps_Load;
            existingData.Cooler_Bed_Depth = updatedData.Cooler_Bed_Depth;
            existingData.Cooler_Air_Opening = updatedData.Cooler_Air_Opening;
            existingData.Cooler_Cool_Speed = updatedData.Cooler_Cool_Speed;
            existingData.Downtime_Hours = updatedData.Downtime_Hours;
            existingData.Downtime_Type = updatedData.Downtime_Type;
            existingData.Downtime_Accountability = updatedData.Downtime_Accountability;
            existingData.Downtime_Remarks = updatedData.Downtime_Remarks;
            existingData.LastModifiedDateTime = DateTime.Now;

            // Save changes to the database
            await _context.SaveChangesAsync();

            //return Ok(responseData);
            return Ok(new { Message = "Pelleting record updated successfully." });
        }
    }
}
