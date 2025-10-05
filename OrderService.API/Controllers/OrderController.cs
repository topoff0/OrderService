using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos.OrderDtos;
using OrderService.Core.Interfaces.Services;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        // Dependencies
        private readonly IOrderService _orderService = orderService;

        // Endpoints
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder
                    (
                        [FromBody] OrderDto createOrderDto,
                        CancellationToken cToken
                    )
        {
            await _orderService.AddAsync(createOrderDto, cToken);
            return Ok();
        }
    }
}