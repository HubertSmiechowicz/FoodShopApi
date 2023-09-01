namespace FoodShop.Entities
{
    public class Order
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public double TotalPrice { get; set; }

        public int TotalQuantity { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
