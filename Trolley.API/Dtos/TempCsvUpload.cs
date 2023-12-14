using Trolley.API.Entities;

namespace Trolley.API.Dtos
{
    public class TempCsvUploadDto
    {
        public string UserName { get; set; }
        public string MarketName { get; set; }
        public string ProductName { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsDiscountProduct { get; set; }
        public double Price { get; set; }
        public string IconName { get; set; }
        public int ProductCategoryId { get; set; }


    }
}
