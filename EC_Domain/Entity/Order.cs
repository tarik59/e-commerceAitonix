﻿using EC_Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EC_Domain.Entity
{
    public class Order : BaseEntity
    {
        public Order()
        {
            products = new List<Product>();
        }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastModified { get; set; }
        public int statusId { get; set; } = 1;
        public Status Status { get; set; }
        [ForeignKey("AppUser")]
        public int userId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
