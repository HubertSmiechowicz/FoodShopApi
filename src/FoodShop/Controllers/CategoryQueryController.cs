using FoodShop.Entities.dtos;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Route("api/category")]
    public class CategoryQueryController : Controller
    {
        private readonly ICategoryQueryService _service;

        public CategoryQueryController(ICategoryQueryService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<CategoryDto> GetCategories() 
        {
            return _service.GetCategories();
        }

        [HttpGet("{id}")]
        public CategoryDto GetCategoryById([FromRoute] int id) 
        {
            return _service.GetCategoryById(id);
        }
    }
}
