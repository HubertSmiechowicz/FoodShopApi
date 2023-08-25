using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            if (string .IsNullOrEmpty(name)) { throw new ArgumentNullException("name"); }
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
            if (category != null)
            {
                _dbContext.Remove(category);
                _dbContext.SaveChanges();
            }
            else { throw new ArgumentNullException(); }
        }

        public Category UpdateCategory(int id, string name)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.Name = name;
                _dbContext.SaveChanges();
                return category;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
