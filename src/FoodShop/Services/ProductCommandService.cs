using AutoMapper;
using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using FoodShop.Entities.dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            if (productDtoToSave == null) { throw new ArgumentNullException("Product cannot be null"); }
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

        public Product UpdateProductPrice(int id, double newPrice)
        {
            if (newPrice <= 0) { throw new ArgumentException("New price cannot be less or equal 0"); }
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) { throw new ArgumentNullException("Product not found"); }
            product.Price = newPrice;
            _dbContext.SaveChanges();
            return product;
        }

        public Product UpdateProductDescription(int id, string newDescription) 
        {
            if (newDescription.IsNullOrEmpty()) { throw new ArgumentNullException("New description cannot be null"); }
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) { throw new ArgumentNullException("Product not found"); }
            product.Description = newDescription;
            _dbContext.SaveChanges();
            return product;
        }
    }
}
