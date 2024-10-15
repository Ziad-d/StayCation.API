using StayCation.API.VerticalSlicing.Common.Enums;

namespace StayCation.API.VerticalSlicing.Data.Models
{
    public class Order : BaseModel
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
