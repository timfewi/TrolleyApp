namespace Trolley.API.Dtos
{
    public class ShoppingListDetailDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductDetailDto> Products { get; set; }
    }
}
