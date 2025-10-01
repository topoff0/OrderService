using OrderService.Core.Dtos.Customer;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Repositories.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task AddAsync(CustomerDto customerDto);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<Customer?> GetByIdAsync(Guid customerId);
        Task<Customer?> GetByEmailAsync(string email);

        Task SaveChangesAsync();
    }
}