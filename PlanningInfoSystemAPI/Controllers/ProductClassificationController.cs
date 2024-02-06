using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Data;

namespace PlanningInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductClassificationController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductClassificationController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<ProductClassification>>> GetProductClassification()
        //{
        //    return Ok(await _context.DowntimeGuide.ToListAsync());
        //}

        [HttpGet]
        public async Task<ActionResult<List<ProductClassification>>> GetProductClassification(string sortOrder = "asc")
        {
            var data = await _context.ProductClassifications.ToListAsync();

            // Sort the data based on sortOrder
            if (sortOrder.ToLower() == "desc")
                data = data.OrderByDescending(x => x.Id).ToList();
            else
                data = data.OrderBy(x => x.Id).ToList();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductClassification>> GetProductClassificationById(int id)
        {
            var productClassification = await _context.ProductClassifications.FindAsync(id);

            if (productClassification == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product classification is not found.
            }

            return Ok(productClassification);
        }


        [HttpPost]
        public async Task<ActionResult<List<ProductClassification>>> CreateProductionClassification(ProductClassification product)
        {
            // Check if the product code already exists
            if (await _context.ProductClassifications.AnyAsync(p => p.Code == product.Code))
            {
                return BadRequest(new APIResponseClass<List<ProductClassification>>
                {
                    Success = false,
                    Message = "Duplicate product code is not allowed."
                });
            }

            product.CreatedDateTime = DateTime.Now;

            _context.ProductClassifications.Add(product);
            await _context.SaveChangesAsync();

            var responseData = await _context.ProductClassifications.ToListAsync();

            return Ok(new APIResponseClass<List<ProductClassification>>
            {
                Success = true,
                //Data = responseData,
                Message = "Product record created successfully."
            });
        }

        //[HttpPut]
        //public async Task<ActionResult<List<ProductClassification>>> UpdateProductClassification(ProductClassification product)
        //{
        //    var dbproduct = await _context.ProductClassifications.FindAsync(product.Id);
        //    if (dbproduct == null)
        //        return BadRequest("Product not found.");

        //    dbproduct.Code = product.Code;
        //    dbproduct.Description = product.Description;

        //    dbproduct.LastModifiedDateTime = DateTime.Now;

        //    await _context.SaveChangesAsync();
        //    // return Ok(await _context.ProductClassifications.ToListAsync());
        //    return Ok(new { Message = "Product record updated successfully." });
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProductClassification>>> UpdateProductClassification(int id, ProductClassification product)
        {
            var dbproduct = await _context.ProductClassifications.FindAsync(id);

            if (dbproduct == null)
                return BadRequest("Product not found.");

            dbproduct.Code = product.Code;
            dbproduct.Description = product.Description;

            dbproduct.LastModifiedDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            //return Ok(await _context.ProductClassifications.ToListAsync());
            return Ok(new { Message = "Product record updated successfully." });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProductClassification>>> DeleteProductClassification(int id)
        {
            var dbproduct = await _context.ProductClassifications.FindAsync(id);
            if (dbproduct == null)
                return BadRequest("Product not found.");

            _context.ProductClassifications.Remove(dbproduct);
            await _context.SaveChangesAsync();
            //return Ok(await _context.ProductClassifications.ToListAsync());
            return Ok(new { Message = "Product record deleted successfully." });
        }
    }
}
