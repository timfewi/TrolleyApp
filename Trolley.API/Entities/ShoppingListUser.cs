using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(ShoppingListUser))]
    public class ShoppingListUser
    {

        public Guid ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
