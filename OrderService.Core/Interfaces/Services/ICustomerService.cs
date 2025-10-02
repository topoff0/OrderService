using OrderService.Core.Dtos.CustomerDtos;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task AddAsync(CustomerDto customerDto, CancellationToken cToken);
        public Task DeleteAsync(Customer customer, CancellationToken cToken);
        public Task UpdateAsync(Customer customer, CancellationToken cToken);
        Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cToken);
        Task<Customer> GetByEmailAsync(string email, CancellationToken cToken);
    }
}