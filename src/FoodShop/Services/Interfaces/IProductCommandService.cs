using FoodShop.Entities;
using FoodShop.Entities.dtos;

namespace FoodShop.Services.Interfaces
{
    public interface IProductCommandService
    {
        Product AddProduct(ProductDtoToSave productDto);

        Product UpdateProductPrice(int id, double newPrice);

        Product UpdateProductDescription(int id, string newDescription);
    }
}