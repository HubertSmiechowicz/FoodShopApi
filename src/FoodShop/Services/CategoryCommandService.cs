using FoodShop.Entities;
using FoodShop.Exceptions;
using FoodShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodShop.Services
{
    public class CategoryCommandService : ICategoryCommandService
    {
        private readonly FoodShopDbContext _dbContext;

        public CategoryCommandService(FoodShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Category AddCategory(string name)
        {
            if (string .IsNullOrEmpty(name)) { throw new ArgumentNullException("Name cannot be null or empty"); }
            var category = new Category()
            {
                Name = name,
                Products = new List<Product>() { }
            };
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return category;
        }

        public void DeleteCategoryById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) { throw new EntityNotFoundException("Category not found. Id: " + id, id); }
            _dbContext.Remove(category);
            _dbContext.SaveChanges();
        }

        public Category UpdateCategory(int id, string name)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) { throw new EntityNotFoundException("Category not found. Id: " + id, id); }
            if (name.IsNullOrEmpty()) { throw new ArgumentNullException("Name cannot be null or empty"); }
            category.Name = name;
            _dbContext.SaveChanges();
            return category;
        }
    }
}
