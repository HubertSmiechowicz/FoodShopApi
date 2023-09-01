using FoodShop.Entities;
using FoodShop.Entities.dtos;

namespace FoodShop.Services.Interfaces
{
    public interface ICustomerCommandService
    {
        Customer AddCustomer(CustomerDtoToWrite customerToWrite);
    }
}