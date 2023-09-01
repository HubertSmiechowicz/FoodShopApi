using FoodShop.Entities.dtos;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Route("api/order")]
    public class OrderQueryController : Controller
    {
        private readonly IOrderQueryService _orderQueryService;

        public OrderQueryController(IOrderQueryService orderQueryService)
        {
            _orderQueryService = orderQueryService;
        }

        [HttpGet("{id}")]
        public OrderDtoToRead GetOrderById([FromRoute] int id)
        {
            return _orderQueryService.GetOrderById(id);
        }
    }
}
