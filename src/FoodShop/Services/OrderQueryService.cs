using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Exceptions;
using FoodShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodShop.Services
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly FoodShopDbContext _dbContext;
        private IMapper _mapper { get; set; }

        public OrderQueryService(FoodShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderDtoToRead GetOrderById(int id)
        {
            var order = _dbContext.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) { throw new EntityNotFoundException("Order not found. Id: " + id, id); }
            var orderDto = _mapper.Map<OrderDtoToRead>(order);
            return orderDto;
        }
    }
}
