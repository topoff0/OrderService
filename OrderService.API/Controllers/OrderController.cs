using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos.Order;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            return Ok();
        }
    }
}