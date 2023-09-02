using FoodShop.Entities;
using FoodShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodShop.Controllers
{
    [Route("api/order")]
    public class OrderCommandController : Controller
    {
        private readonly IOrderCommandService _orderCommandService;

        public OrderCommandController(IOrderCommandService orderCommandService)
        {
            _orderCommandService = orderCommandService;
        }

        [HttpPost("{customerId}")]
        public void CreateOrder([FromRoute] int customerId)
        {
            _orderCommandService.CreateOrder(customerId);
        }

        [HttpPost("product/{orderId}/{productId}/{productQuantity}")]
        public void AddProductToOrder([FromRoute] int orderId, [FromRoute] int productId, [FromRoute] int productQuantity)
        {
            _orderCommandService.AddProductToOrder(orderId, productId, productQuantity);
        }

        [HttpPatch("status/{orderId}")]
        public void PlacedOrder(int orderId)
        {
            _orderCommandService.PlacedOrder(orderId);
        }
    }
}
