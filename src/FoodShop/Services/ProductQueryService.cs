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

        public List<ProductDtoToRead> GetAllProducts(int sortedBy)
        {
            var products = _dbContext.Products.ToList();
            var sortTool = new FilterSortOperationTool();
            var sort = (Sorted)sortedBy;
            var sortedProducts = sortTool.ProductSortBy(sort, products);
            var productsDto = _mapper.Map<List<ProductDtoToRead>>(sortedProducts);
            return productsDto;
        }

        public ProductDtoToRead GetProductById(int id) 
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) { throw new ArgumentNullException("Product not found"); }
            var productDto = _mapper.Map<ProductDtoToRead>(product);
            return productDto;
        }

        public List<ProductDtoToRead> GetProductsByCategoryId(int categoryId, int sortedBy) 
        {
            var products = _dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
            var sortTool = new FilterSortOperationTool();
            var sort = (Sorted)sortedBy;
            var sortedProducts = sortTool.ProductSortBy(sort, products);
            var productsDto = _mapper.Map<List<ProductDtoToRead>>(sortedProducts);
            return productsDto;
        }

        public List<ProductDtoToRead> GetProductByPriceRange(double priceDownLimit, double priceUpLimit, int sortedBy)
        {
            var product = _dbContext.Products.Where(p => p.Price > priceDownLimit && p.Price < priceUpLimit).ToList();
            var sortTool = new FilterSortOperationTool();
            var sort = (Sorted)sortedBy;
            var sortedProducts = sortTool.ProductSortBy(sort, product);
            var productsDto = _mapper.Map<List<ProductDtoToRead>>(sortedProducts);
            return productsDto;
        }
    }
}
