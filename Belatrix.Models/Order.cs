using System;
using System.Collections.Generic;

namespace Belatrix.WebApi.Models
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Customer RelatedCustomer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
