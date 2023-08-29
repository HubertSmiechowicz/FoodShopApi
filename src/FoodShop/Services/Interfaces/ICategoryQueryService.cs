using FoodShop.Entities.dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Services.Interfaces
{
    public interface ICategoryQueryService
    {
        List<CategoryDto> GetCategories(int sortedBy);
        SingleCategoryDto GetCategoryById([FromQuery] int id);
    }
}