using OrderService.Infrastructure.Data;
using OrderService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Core.Dtos.CustomerDtos;

namespace OrderService.Infrastructure.Repositories
{
    public class CustomerRepository(ApplicationDbContext db) : ICustomerRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task AddAsync(CustomerDto customerDto)
        {
            await _db.AddAsync(new Customer(customerDto.Name, customerDto.Email));
        }

        public void Delete(Customer customer)
        {
            _db.Remove(customer);
        }

        public void Update(Customer customer)
        {
            _db.Update(customer);
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await _db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer?> GetByIdAsync(Guid customerId)
        {
            return await _db.Customers
                .Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}