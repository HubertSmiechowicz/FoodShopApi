using FoodShop.Entities.dtos;
using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Route("api/customer")]
    public class CustomerCommandController : Controller
    {
        private readonly ICustomerCommandService _customerCommandService;

        public CustomerCommandController(ICustomerCommandService customerCommandService)
        {
            _customerCommandService = customerCommandService;
        }

        [HttpPost]
        public Customer AddCustomer([FromBody] CustomerDtoToWrite customerToWrite)
        {
            return _customerCommandService.AddCustomer(customerToWrite);
        }
    }
}
