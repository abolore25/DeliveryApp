using System;
using DeliverApp.Data;

namespace DeliveryApp.Data
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public User User { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; } = default!;
     }
}