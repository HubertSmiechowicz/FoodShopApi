using AutoMapper;
using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodShop.Entities.dtos;

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

        public List<CategoryDto> GetCategories()
        {
            var categories = _dbContext.Categories
                .Include(c => c.Products)
                .ToList();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDto;
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                throw new EntryPointNotFoundException();
            }
            else
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return categoryDto;
            }
           
        }
    }
}
