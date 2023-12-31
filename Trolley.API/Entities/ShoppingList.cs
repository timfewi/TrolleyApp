﻿using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(ShoppingList))]
    public class ShoppingList : BaseEntity
    {
        public string Name { get; set; }
        public string? ShareLink { get; set; }
        // Navigation properties
        public ICollection<ProductShoppingList> ProductShoppingLists { get; set; }
        public virtual ICollection<UserShoppingList> UserShoppingLists { get; set; }
    }

}

