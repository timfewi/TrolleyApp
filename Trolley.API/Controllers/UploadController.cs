using System.Globalization;
using System.Security.Claims;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
namespace Trolley.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ShopOwner,Admin")]
    public class UploadController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UploadController(IServiceProvider serviceProvider, IWebHostEnvironment webHostEnvironment) : base(serviceProvider)
        {
            _hostingEnvironment = webHostEnvironment;
        }


        // POST: api/Upload/Csv
        [HttpPost("Csv")]
        public async Task<IActionResult> UploadCsv(IFormFile file, [FromForm] string userId, [FromForm] string marketName)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Datei ist leer oder nicht vorhanden.");

            var tempProducts = new List<TempCsvUploadDto>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Trim(),
            };
            using (var stream = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(stream, config))
            {
                tempProducts = csv.GetRecords<TempCsvUploadDto>().ToList();
            }

            foreach (var tempProduct in tempProducts)
            {
                var tempEntity = new TempCsvUpload
                {
                    UserId = userId,
                    MarketName = marketName,
                    ProductName = tempProduct.ProductName,
                    IsOrganic = tempProduct.IsOrganic,
                    IsDiscountProduct = tempProduct.IsDiscountProduct,
                    Price = tempProduct.Price,
                    IconName = tempProduct.IconName,
                    ProductCategoryId = tempProduct.ProductCategoryId
                };

                _context.TempCsvUploads.Add(tempEntity);
            }

            await _context.SaveChangesAsync();


            return Ok(
                new
                {
                    status = 200,
                    message = "Datei erfolgreich hochgeladen."

                });
        }
    }
}
