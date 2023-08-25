using FoodShop.Entities;
using FoodShop.Entities.dtos;

namespace FoodShop.Services.Interfaces
{
    public interface IProductCommandService
    {
        Product AddProduct(ProductDtoToSave productDto);
    }
}