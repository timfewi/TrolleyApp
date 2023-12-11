

namespace Trolley.API.Dtos
{
    public class CreateShoppingListAndAddListOfProductsDto
    {

        public int ShoppingListId { get; set; }
        public string Name { get; set; }
        public List<ProductItemDto> Products { get; set; }


    }
}
