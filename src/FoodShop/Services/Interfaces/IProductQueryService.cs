using FoodShop.Entities;
using FoodShop.Entities.dtos;

namespace FoodShop.Services.Interfaces
{
    public interface IProductQueryService
    {
        List<ProductDtoToRead> GetAllProducts(int sortedBy);

        ProductDtoToRead GetProductById(int id);

        List<ProductDtoToRead> GetProductsByCategoryId(int categoryId, int sortedBy);

        List<ProductDtoToRead> GetProductByPriceRange(double priceDownLimit, double priceUpLimit, int sortedBy);
    }
}