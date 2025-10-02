using Microsoft.AspNetCore.Mvc;
using OrderService.Core.Dtos.CustomerDtos;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        // [HttpPost("create")]
        // public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        // {
        //     return Ok();
        // }
    }
}