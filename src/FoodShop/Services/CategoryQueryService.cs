using AutoMapper;
using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodShop.Entities.dtos;
using FoodShop.Services.Tools;

namespace FoodShop.Services
{
    public class CategoryQueryService : ICategoryQueryService
    {
        private readonly FoodShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryQueryService(FoodShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CategoryDto> GetCategories(Sorted sortedBy)
        {
            var categories = _dbContext.Categories.ToList();
            var sortTool = new FilterSortCategoryOperationTool(sortedBy);
            var categoriesSorted = sortTool.CategorySortBy(categories);
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categoriesSorted);
            return categoriesDto;
        }

        public SingleCategoryDto GetCategoryById(int id)
        {
            var category = _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);

            if (category == null) { throw new EntryPointNotFoundException(); }
            var categoryDto = _mapper.Map<SingleCategoryDto>(category);
            return categoryDto;
        }
    }
}
