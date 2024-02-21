using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Data;

namespace PlanningInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DowntimeGuideController : ControllerBase
    {
        private readonly DataContext _context;
        public DowntimeGuideController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<DowntimeGuide>>> GetDowntimeGuide()
        //{
        //    return Ok(await _context.DowntimeGuide.ToListAsync());
        //}

        [HttpGet]
        public async Task<ActionResult<List<DowntimeGuide>>> GetDowntimeGuide(string sortOrder = "asc")
        {
            var data = await _context.DowntimeGuide.ToListAsync();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                data = data.OrderByDescending(x => x.Id).ToList();
            else
                data = data.OrderBy(x => x.Id).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DowntimeGuide>> GetDowntimeGuideById(int id)
        {
            var downtimeGuide = await _context.DowntimeGuide.FindAsync(id);

            if (downtimeGuide == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product classification is not found.
            }

            return Ok(downtimeGuide);
        }

        [HttpPost]
        public async Task<ActionResult<List<DowntimeGuide>>> CreateDowntimeGuide(DowntimeGuide downtime)
        {
            downtime.CreatedDateTime = DateTime.Now;

            _context.DowntimeGuide.Add(downtime);
            await _context.SaveChangesAsync();

            // return Ok(await _context.DowntimeGuide.ToListAsync());
            return Ok(new { Message = "Downtime record created successfully." });
        }

        //[HttpPut]
        //public async Task<ActionResult<List<DowntimeGuide>>> UpdateDowntimeGuide(DowntimeGuide downtime)
        //{
        //    var dbdowntime = await _context.DowntimeGuide.FindAsync(downtime.Id);
        //    if (dbdowntime == null)
        //        return BadRequest("Downtime not found.");

        //    dbdowntime.Classification = downtime.Classification;
        //    dbdowntime.Description = downtime.Description;
        //    dbdowntime.Accountability = downtime.Accountability;

        //    dbdowntime.LastModifiedDateTime = DateTime.Now;

        //    await _context.SaveChangesAsync();
        //    // return Ok(await _context.DowntimeGuide.ToListAsync());
        //    return Ok(new { Message = "Downtime guide update successfully." });
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DowntimeGuide>>> UpdateDowntimeGuide(int id, DowntimeGuide downtime)
        {
            var dbdowntime = await _context.DowntimeGuide.FindAsync(id);

            if (dbdowntime == null)
                return BadRequest("Downtime not found.");

            dbdowntime.Classification = downtime.Classification;
            dbdowntime.Description = downtime.Description;
            dbdowntime.Accountability = downtime.Accountability;

            dbdowntime.LastModifiedDateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            // return Ok(await _context.DowntimeGuide.ToListAsync());
            return Ok(new { Message = "Downtime record updated successfully." });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DowntimeGuide>>> DeleteDowntimeGuide(int id)
        {
            var dbdowntime = await _context.DowntimeGuide.FindAsync(id);
            if (dbdowntime == null)
                return BadRequest("Downtime not found.");

            _context.DowntimeGuide.Remove(dbdowntime);
            await _context.SaveChangesAsync();

            // return Ok(await _context.DowntimeGuide.ToListAsync());
            return Ok(new { Message = "Downtime record deleted successfully." });
        }

        [HttpDelete("delete-multiple")]
        public async Task<ActionResult> DeleteMultipleDowntimeGuide([FromBody] List<int> ids)
        {
            var downtimeToDelete = await _context.DowntimeGuide.Where(p => ids.Contains(p.Id)).ToListAsync();

            if (downtimeToDelete == null || downtimeToDelete.Count == 0)
                return BadRequest("Downtime record not found.");

            _context.DowntimeGuide.RemoveRange(downtimeToDelete);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Downtime records deleted successfully." });
        }
    }
}
