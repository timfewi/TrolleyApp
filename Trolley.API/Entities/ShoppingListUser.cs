using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(ShoppingListUser))]
    public class ShoppingListUser : BaseEntity
    {

        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
