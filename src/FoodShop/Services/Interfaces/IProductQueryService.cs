using FoodShop.Entities;
using FoodShop.Entities.dtos;

namespace FoodShop.Services.Interfaces
{
    public interface IProductQueryService
    {
        List<ProductDtoToRead> GetAllProducts();
    }
}