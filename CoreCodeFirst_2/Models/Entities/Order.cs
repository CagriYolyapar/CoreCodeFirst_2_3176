﻿namespace CoreCodeFirst_2.Models.Entities
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
