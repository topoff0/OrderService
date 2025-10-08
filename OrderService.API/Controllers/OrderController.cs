using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos;
using OrderService.Core.Enums;
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
            var order = await _orderService.AddAsync(createOrderDto, cToken);
            await _kafkaProducer.PublishAsync("order_created", order.Id.ToString(), new
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                CustomerEmail = order.Customer.Email,
                TotalAmount = order.TotalAmount,
                OrderStatus = order.Status,
                CreatedAt = DateTime.UtcNow
            });
            return Ok();
        }
    }
}