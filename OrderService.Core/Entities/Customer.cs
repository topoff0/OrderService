
using OrderService.Core.Dtos;

namespace OrderService.Core.Entities
{
    public class Customer
    {
        public Customer(CreateDtos.CreateCustomerDto dto)
        {
            Name = dto.Name;
            Email = dto.Email;
        }

        private Customer() { }

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = [];
    }
}