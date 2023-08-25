using FoodShop.Entities;

namespace FoodShop.Services.Interfaces
{
    public interface ICategoryCommandService
    {
        Category AddCategory(string name);
        void DeleteCategoryById(int id);
        Category UpdateCategory(int id, string name);

    }
}