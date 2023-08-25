using AutoMapper;
using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Services.Interfaces;

namespace FoodShop.Services
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly FoodShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductQueryService(FoodShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ProductDtoToRead> GetAllProducts()
        {
            var products = _dbContext.Products.ToList();
            var productsDto = _mapper.Map<List<ProductDtoToRead>>(products);
            return productsDto;
        }
    }
}
