

namespace Trolley.API.Dtos
{
    public class CreateShoppingListAndAddListOfProductsDto
    {

        public string Name { get; set; }
        public List<ProductItemDto> Products { get; set; }


    }
}
