using FoodShop.Entities;
using Microsoft.AspNetCore.Mvc;
using FoodShop.Services.Interfaces;
using FoodShop.Entities.dtos;

namespace FoodShop.Controllers
{
    [Route("api/product")]
    public class ProductCommandController : Controller
    {
        private readonly IProductCommandService _commandService;

        public ProductCommandController(IProductCommandService commandService) 
        {
            _commandService = commandService;
        }

        // do naprawy _____________________________________
        [HttpPost]
        public Product AddProduct([FromBody] ProductDtoToSave productDtoToSave)
        {
            return _commandService.AddProduct(productDtoToSave);
        }
        // ________________________________________________
    }
}
