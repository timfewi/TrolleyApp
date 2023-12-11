namespace Trolley.API.Dtos
{
    public class ShoppingListGetAllDto
    {

        public int? Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, double> CostPerMarket { get; set; }
        public List<ProductItemDto> Items { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
