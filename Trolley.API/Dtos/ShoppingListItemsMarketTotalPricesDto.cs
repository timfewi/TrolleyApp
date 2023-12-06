namespace Trolley.API.Dtos
{
    public class ShoppingListItemsMarketTotalPricesDto
    {
        public List<MarketTotalPriceDto> MarketTotalPrices { get; set; }
        public List<ProductAmountDto> Items { get; set; }
    }
}
