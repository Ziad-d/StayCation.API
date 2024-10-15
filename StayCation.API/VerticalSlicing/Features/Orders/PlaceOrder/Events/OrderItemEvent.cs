namespace StayCation.API.VerticalSlicing.Features.Orders.PlaceOrder.Events
{
    public class OrderItemEvent
    {
        public int RecipeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
