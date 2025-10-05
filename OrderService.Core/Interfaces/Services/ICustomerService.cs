using OrderService.Core.Dtos;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task AddAsync(CreateDtos.CreateCustomerDto customerDto, CancellationToken cToken);
        Task DeleteAsync(Customer customer, CancellationToken cToken);
        Task UpdateAsync(Customer customer, CancellationToken cToken);
        Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cToken);
        Task<Customer> GetByEmailAsync(string email, CancellationToken cToken);
    }
}