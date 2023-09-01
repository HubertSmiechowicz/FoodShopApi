using FoodShop.Entities.dtos;
using FoodShop.Services.Tools;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Services.Interfaces
{
    public interface ICategoryQueryService
    {
        List<CategoryDto> GetCategories(Sorted sortedBy);
        SingleCategoryDto GetCategoryById([FromQuery] int id);
    }
}