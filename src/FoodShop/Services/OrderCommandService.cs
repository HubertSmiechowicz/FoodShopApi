using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
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
            if (_dbContext.Customers.FirstOrDefault(c => c.Id == customerId) == null) { throw new ArgumentNullException(); }
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
            if (product == null) { throw new ArgumentNullException(); }
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) { throw new ArgumentNullException(); }
            var orderProduct = new OrderProduct();
            orderProduct.ProductId = productId;
            orderProduct.OrderId = orderId;
            orderProduct.ProductQuantity = productQuantity;
            order.TotalPrice += product.Price * orderProduct.ProductQuantity;
            order.TotalQuantity += orderProduct.ProductQuantity;
            _dbContext.OrderProducts.Add(orderProduct);
            _dbContext.SaveChanges();
        }
    }
}
