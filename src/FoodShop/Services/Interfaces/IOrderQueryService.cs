using FoodShop.Entities.dtos;

namespace FoodShop.Services.Interfaces
{
    public interface IOrderQueryService
    {
        OrderDtoToRead GetOrderById(int id);
    }
}