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


        [HttpPost]
        public Product AddProduct([FromBody] ProductDtoToSave productDtoToSave)
        {
            return _commandService.AddProduct(productDtoToSave);
        }

        [HttpPatch("price/{id}/{newPrice}")]
        public Product UpdateProductPrice([FromRoute] int id, [FromRoute] double newPrice)
        {
            return _commandService.UpdateProductPrice(id, newPrice);
        }

        [HttpPatch("description/{id}/{newDescription}")]
        public Product UpdateProductDescription([FromRoute] int id, [FromRoute] string newDescription) 
        {
            return _commandService.UpdateProductDescription(id, newDescription);
        }

    }
}
