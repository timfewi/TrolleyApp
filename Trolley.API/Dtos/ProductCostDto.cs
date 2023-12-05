namespace Trolley.API.Dtos
{
    public class ProductCostDto
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; } // Gesamtpreis für dieses Produkt (UnitPrice * Quantity)
    }
}
