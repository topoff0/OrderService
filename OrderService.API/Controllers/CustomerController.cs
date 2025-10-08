using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos;
using OrderService.Core.Interfaces.Services;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController
                (
                    ICustomerService customerService
                )
                : ControllerBase
    {
        // Dependencies
        private readonly ICustomerService _customerService = customerService;

        // Endpoints
        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer
                    (
                        [FromBody] CreateDto.CreateCustomerDto customerDto,
                        CancellationToken cToken
                    )
        {
            var customer = await _customerService.AddAsync(customerDto, cToken);
            return Ok();
        }
    }
}