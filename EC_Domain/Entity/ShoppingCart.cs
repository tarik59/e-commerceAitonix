﻿using EC_Domain.Identity;
using System.Collections.Generic;

namespace EC_Domain.Entity
{
    public class ShoppingCart : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public virtual ICollection<Product> products { get; set; } = new List<Product>();
    }
}
