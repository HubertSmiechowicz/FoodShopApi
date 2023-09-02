namespace FoodShop.Exceptions
{
    [Serializable]
    public class OrderStatusNotChangedException : Exception
    {
        public OrderStatusNotChangedException() { }

        public OrderStatusNotChangedException(string message) : base(message) { }

        public OrderStatusNotChangedException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
