namespace Trolley.API.Dtos
{
    public class ProductReadDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsDiscountProduct { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public string IconName { get; set; }

    }
}
