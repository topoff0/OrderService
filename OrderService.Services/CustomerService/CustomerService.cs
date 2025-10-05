
using OrderService.Core.Dtos.CustomerDtos;
using OrderService.Core.Entities;
using OrderService.Core.Exceptions;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Core.Interfaces.Services;

namespace OrderService.Services.CustomerService
{
    public class CustomerService(ICustomerRepository customerRepo) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo = customerRepo;

        public async Task AddAsync(CustomerDto customerDto, CancellationToken cToken)
        {
            await _customerRepo.AddAsync(customerDto, cToken);
            await _customerRepo.SaveChangesAsync(cToken);
        }

        public async Task DeleteAsync(Customer customer, CancellationToken cToken)
        {
            _customerRepo.Delete(customer);
            await _customerRepo.SaveChangesAsync(cToken);
        }

        public async Task<Customer> GetByEmailAsync(string email, CancellationToken cToken)
        {
            var customer = await _customerRepo.GetByEmailAsync(email, cToken);
            if (customer is null)
                throw new RecordNotFoundException("Customer with this email not found");
            return customer;
        }

        public async Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cToken)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId, cToken);
            if (customer is null)
                throw new RecordNotFoundException("Customer with this Id not found");
            return customer;
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cToken)
        {
            _customerRepo.Update(customer);
            await _customerRepo.SaveChangesAsync(cToken);
        }
    }
}