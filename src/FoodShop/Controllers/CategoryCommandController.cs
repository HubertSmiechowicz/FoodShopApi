using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Route("api/category")]
    public class CategoryCommandController : Controller
    {
        private readonly ICategoryCommandService _service;

        public CategoryCommandController(ICategoryCommandService service)
        {
            _service = service;
        }

        [HttpPost]
        public Category AddCategory(string name)
        {
            return _service.AddCategory(name);
        }

        [HttpDelete]
        public void DeleteCategoryById(int id) 
        {
            _service.DeleteCategoryById(id);
        }

        [HttpPatch]
        public Category UpdateCategory(int id, string name)
        {
            return _service.UpdateCategory(id, name);
        }
    }
}
