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

        [HttpGet]
        public List<ProductDtoToRead> GetAllProducts()
        {
            return _queryService.GetAllProducts();
        }
    }
}
