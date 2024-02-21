using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
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

        [HttpGet("list")]
        public async Task<ActionResult<List<ProductClassification>>> GetProductClassifications()
        {
            var data = await _context.ProductClassifications.ToListAsync();

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

        public class UploadResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcel()
        {
            var response = new UploadResponse();

            try
            {
                var file = Request.Form.Files[0]; // Assuming only one file is uploaded

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            var rowCount = worksheet.Dimension.Rows;
                            var products = new List<ProductClassification>();

                            for (int row = 2; row <= rowCount; row++) // Assuming header is in row 1
                            {
                                var code = worksheet.Cells[row, 1].Value?.ToString();
                                var description = worksheet.Cells[row, 2].Value?.ToString();

                                if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(description))
                                {
                                    // Check if the code already exists
                                    if (_context.ProductClassifications.Any(p => p.Code == code))
                                    {
                                        response.Success = false;
                                        response.Message = $"Duplicate product code '{code}' is not allowed.";
                                        return BadRequest(response);
                                    }

                                    products.Add(new ProductClassification
                                    {
                                        Code = code,
                                        Description = description,
                                        CreatedDateTime = DateTime.Now
                                    });
                                }
                            }

                            // Now 'products' list contains data from Excel file.
                            // Save the products to the database
                            _context.ProductClassifications.AddRange(products);
                            await _context.SaveChangesAsync();

                            response.Success = true;
                            response.Message = "Data uploaded successfully.";
                            return Ok(response);
                        }
                    }
                }

                response.Success = false;
                response.Message = "Invalid Excel file.";
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Internal server error: {ex}";
                return StatusCode(500, response);
            }
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

        //[HttpPut("{id}")]
        //public async Task<ActionResult<List<ProductClassification>>> UpdateProductClassification(int id, ProductClassification product)
        //{
        //    var dbproduct = await _context.ProductClassifications.FindAsync(id);

        //    if (dbproduct == null)
        //        return BadRequest("Product not found.");

        //    dbproduct.Code = product.Code;
        //    dbproduct.Description = product.Description;

        //    dbproduct.LastModifiedDateTime = DateTime.Now;

        //    await _context.SaveChangesAsync();

        //    //return Ok(await _context.ProductClassifications.ToListAsync());
        //    return Ok(new { Message = "Product record updated successfully." });
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductClassification>> UpdateProductClassification(int id, ProductClassification product)
        {
            var dbproduct = await _context.ProductClassifications.FindAsync(id);

            if (dbproduct == null)
            {
                return NotFound();
            }

            // Check if any properties have changed
            if (product.Code != dbproduct.Code ||
                product.Description != dbproduct.Description)
            {
                dbproduct.Code = product.Code;
                dbproduct.Description = product.Description;
            }

            // Update LastModifiedDateTime to current time
            dbproduct.LastModifiedDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

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

        [HttpDelete("delete-multiple")]
        public async Task<ActionResult> DeleteMultipleProductClassifications([FromBody] List<int> ids)
        {
            var productsToDelete = await _context.ProductClassifications.Where(p => ids.Contains(p.Id)).ToListAsync();

            if (productsToDelete == null || productsToDelete.Count == 0)
                return BadRequest("Products not found.");

            _context.ProductClassifications.RemoveRange(productsToDelete);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Products deleted successfully." });
        }

    }
}
