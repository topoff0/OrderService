using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos;
using OrderService.Core.Interfaces.Services;
using OrderService.Infrastructure.Messaging;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService orderService, IKafkaProducer kafkaProducer) : ControllerBase
    {
        // Dependencies
        private readonly IOrderService _orderService = orderService;
        private readonly IKafkaProducer _kafkaProducer = kafkaProducer;
        // Endpoints
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder
                    (
                        [FromBody] CreateDto.CreateOrderDto createOrderDto,
                        CancellationToken cToken
                    )
        {
            await _orderService.AddAsync(createOrderDto, cToken);
            await _kafkaProducer.PublishAsync("order_created", createOrderDto.CreatedAt.ToString(), new
            {
                CustomerId = createOrderDto.CustomerDto.Id,
                OrderId = createOrderDto.CustomerDto.Email,
                TotalAmount = createOrderDto.Status,
                CreatedAt = DateTime.UtcNow
            });
            return Ok();
        }
    }
}