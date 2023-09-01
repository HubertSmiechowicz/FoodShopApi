using FoodShop.Entities.dtos;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FoodShop.Services.Tools;

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

        [HttpGet("all/{sortedBy}")]
        public List<CategoryDto> GetCategories([FromRoute] Sorted sortedBy) 
        {
            return _service.GetCategories(sortedBy);
        }

        [HttpGet("{id}")]
        public SingleCategoryDto GetCategoryById([FromRoute] int id) 
        {
            return _service.GetCategoryById(id);
        }
    }
}
