namespace FoodShop.Entities.dtos
{
    public class OrderDtoToRead
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public double TotalPrice { get; set; }

        public int TotalQuantity { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderProductDtoToRead> OrderProducts { get; set; }
    }
}
