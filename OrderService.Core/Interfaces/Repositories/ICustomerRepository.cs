using OrderService.Core.Dtos.CustomerDtos;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(CustomerDto customerDto, CancellationToken cToken);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cToken);
        Task<Customer?> GetByEmailAsync(string email, CancellationToken cToken);
        Task SaveChangesAsync(CancellationToken cToken);
    }
}