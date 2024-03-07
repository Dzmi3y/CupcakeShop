using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CupcakeShop.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Guid))]
        [SwaggerOperation(Summary = "Get bestsellers")]

        public async Task<IActionResult> SaveOrder(OrderDTO orderDTO)
        {
            var orderid = await _orderService.SaveOrderAsync(orderDTO);
            return orderid != null ? Ok(orderid) : StatusCode(500);
        }
    }
}
