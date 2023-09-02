using FoodShop.Entities;

namespace FoodShop.Services.Interfaces
{
    public interface IOrderCommandService
    {
        void AddProductToOrder(int orderId, int productId, int productQuantity);
        void CreateOrder(int customerId);

        void PlacedOrder(int orderId);
    }
}