namespace Trolley.API.Dtos
{
    public class AddProductToShoppingListDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
