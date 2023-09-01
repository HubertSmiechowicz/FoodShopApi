using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Services.Interfaces;

namespace FoodShop.Services
{
    public class CustomerCommandService : ICustomerCommandService
    {
        private readonly FoodShopDbContext _dbContext;
        private IMapper _mapper;

        public CustomerCommandService(FoodShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Customer AddCustomer(CustomerDtoToWrite customerToWrite)
        {
            var customer = _mapper.Map<Customer>(customerToWrite);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
    }
}
