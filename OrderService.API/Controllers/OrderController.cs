using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos.OrderDtos;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        // [HttpPost("create")]
        // public async Task<IActionResult> CreateOrder(OrderDto createOrderDto)
        // {
        //     return Ok();
        // }
    }
}