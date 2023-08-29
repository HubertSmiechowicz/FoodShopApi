using FoodShop.Services.Interfaces;
using FoodShop.Entities;
using Microsoft.AspNetCore.Mvc;
using FoodShop.Entities.dtos;

namespace FoodShop.Controllers
{
    [Route("api/product")]
    public class ProductQueryController : Controller
    {
        private readonly IProductQueryService _queryService;

        public ProductQueryController(IProductQueryService queryService) 
        {
            _queryService = queryService;
        }

        [HttpGet("all/{sortedBy}")]
        public List<ProductDtoToRead> GetAllProducts([FromRoute] int sortedBy)
        {
            return _queryService.GetAllProducts(sortedBy);
        }

        [HttpGet("{id}")]
        public ProductDtoToRead GetProductById([FromRoute] int id)
        {
            return _queryService.GetProductById(id);
        }

        [HttpGet("category/{categoryId}/ {sortedBy}")]
        public List<ProductDtoToRead> GetProductsByCategoryId([FromRoute] int categoryId, [FromRoute] int sortedBy) 
        {
            return _queryService.GetProductsByCategoryId(categoryId, sortedBy);
        }

        [HttpGet("price/{priceDownLimit}/{priceUpLimit}/{sortedBy}")]
        public List<ProductDtoToRead> GetProductByPriceRange([FromRoute] double priceDownLimit, [FromRoute] double priceUpLimit, [FromRoute] int sortedBy)
        {
            return _queryService.GetProductByPriceRange(priceDownLimit, priceUpLimit, sortedBy);
        }
    }
}
