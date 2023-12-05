namespace Trolley.API.Dtos
{
    public class ShoppingListMarketCostDto
    {
        public string MarketName { get; set; }
        public double TotalCost { get; set; }
        public List<ProductCostDto> Items { get; set; }
    }

}
