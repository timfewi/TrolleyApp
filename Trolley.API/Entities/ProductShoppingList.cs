using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(ProductShoppingList))]
    public class ProductShoppingList : BaseEntity
    {
        public int Amount { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }
}
