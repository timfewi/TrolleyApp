namespace Trolley.API.Dtos
{
    public class ConvertedShoppingListDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, double> CostPerMarket { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
