using FoodShop.Entities;
using FoodShop.Entities.dtos;
using FoodShop.Services.Tools;

namespace FoodShop.Services.Interfaces
{
    public interface IProductQueryService
    {
        List<ProductDtoToRead> GetAllProducts(Sorted sortedBy);

        ProductDtoToRead GetProductById(int id);

        List<ProductDtoToRead> GetProductsByNameFragmentContains(string nameFragment, Sorted sortedBy);

        List<ProductDtoToRead> GetProductsByCategoryId(int categoryId, Sorted sortedBy);

        List<ProductDtoToRead> GetProductByPriceRange(double priceDownLimit, double priceUpLimit, Sorted sortedBy);
    }
}