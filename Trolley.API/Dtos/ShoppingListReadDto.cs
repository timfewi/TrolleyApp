namespace Trolley.API.Dtos
{
    public class ShoppingListReadDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }

        public Dictionary<string, double> CostPerMarket { get; set; }
        public bool IsCheapest { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
