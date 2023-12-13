namespace Trolley.API.Dtos
{
    public class CsvProductFileDto
    {
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsDiscountProduct { get; set; }
        public double Price { get; set; }
        public string IconName { get; set; }

    }
}
