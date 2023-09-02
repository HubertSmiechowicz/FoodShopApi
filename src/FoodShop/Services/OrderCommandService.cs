using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Exceptions;
using FoodShop.Services.Interfaces;

namespace FoodShop.Services
{
    public class OrderCommandService : IOrderCommandService
    {

        private readonly FoodShopDbContext _dbContext;
        private IMapper _mapper { get; set; }

        public OrderCommandService(FoodShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void CreateOrder(int customerId)
        {
            if (_dbContext.Customers.FirstOrDefault(c => c.Id == customerId) == null) { throw new EntityNotFoundException("Customer not found. Id: " + customerId, customerId); }
            Order order = new Order()
            {
                CustomerId = customerId,
                TotalPrice = 0,
                TotalQuantity = 0,
                OrderStatus = OrderStatus.ORDER_CREATED,
                OrderProducts = new List<OrderProduct>() { },
            };
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void AddProductToOrder(int orderId, int productId, int productQuantity)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) { throw new EntityNotFoundException("Product not found. Id: " + productId, productId); }
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) { throw new EntityNotFoundException("Product not found. Id: " + orderId, orderId); }
            var orderProduct = new OrderProduct();
            orderProduct.ProductId = productId;
            orderProduct.OrderId = orderId;
            orderProduct.ProductQuantity = productQuantity;
            order.TotalPrice += product.Price * orderProduct.ProductQuantity;
            order.TotalQuantity += orderProduct.ProductQuantity;
            _dbContext.OrderProducts.Add(orderProduct);
            _dbContext.SaveChanges();
        }

        public void PlacedOrder(int orderId)
        {
            MailService mailService = new MailService(_dbContext);
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) { throw new EntityNotFoundException("Order not found. Id: " + orderId, orderId); }
            if (order.OrderStatus != OrderStatus.ORDER_CREATED && order.OrderStatus != OrderStatus.ORDER_PLACED || order.OrderStatus == OrderStatus.ORDER_PLACED) { throw new OrderIsAlreadyPlacedException($"Order id {orderId} is already placed", orderId); }
            order.OrderStatus = OrderStatus.ORDER_PLACED;
            _dbContext.SaveChanges();
            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == order.CustomerId);
            if (customer == null) { throw new EntityNotFoundException("Customer not found. Id: " + order.CustomerId, order.CustomerId); }
            mailService.SentEmailOrderPlaced
                (
                orderId, 
                customer.Email, 
                "Status zamówienia", 
                $"Dziękujemy za złożenie zamówienia o numerze: {order.Id}. O dalszym przebiegu zamówienia będziemy informować mailowo."
                );
        }

        public void ChangeOrderStatus(int orderId, OrderStatus status)
        {

        }
    }
}
