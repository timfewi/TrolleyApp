using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(ProductShoppingList))]
    public class ProductShoppingList
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
