namespace FoodShop.Exceptions
{
    [Serializable]
    public class OrderIsAlreadyPlacedException : Exception
    {

        public int OrderId { get; }

        public OrderIsAlreadyPlacedException() { }

        public OrderIsAlreadyPlacedException(string message) 
            : base(message) { }

        public OrderIsAlreadyPlacedException(string message, Exception innerException) 
            : base(message, innerException) { }

        public OrderIsAlreadyPlacedException(string message, int orderId)
            : base(message) 
        {
            OrderId = orderId;
        }
    }
}
