using FoodShop.Entities.dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Services.Interfaces
{
    public interface ICategoryQueryService
    {
        List<CategoryDto> GetCategories();
        CategoryDto GetCategoryById([FromQuery] int id);
    }
}