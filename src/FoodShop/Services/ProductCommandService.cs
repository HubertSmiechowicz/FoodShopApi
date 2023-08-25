using AutoMapper;
using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using FoodShop.Entities.dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Services
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly FoodShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductCommandService(FoodShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Product AddProduct(ProductDtoToSave productDtoToSave)
        {
            if (productDtoToSave == null) { throw new ArgumentNullException(); }
            var productDto = new ProductDtoToSave()
            {
                Name = productDtoToSave.Name,
                CategoryId = productDtoToSave.CategoryId,
                Price = productDtoToSave.Price,
                Description = productDtoToSave.Description
            };
            var product = _mapper.Map<Product>(productDto);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }
    }
}
