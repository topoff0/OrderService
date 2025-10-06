using OrderService.Infrastructure.Data;
using OrderService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Core.Dtos;

namespace OrderService.Infrastructure.Repositories
{
    public class CustomerRepository(ApplicationDbContext db) : ICustomerRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task AddAsync(CreateDto.CreateCustomerDto customerDto, CancellationToken cToken)
        {
            await _db.AddAsync(new Customer(customerDto), cancellationToken: cToken);
        }

        public void Delete(Customer customer)
        {
            _db.Remove(customer);
        }

        public void Update(Customer customer)
        {
            _db.Update(customer);
        }

        public async Task<Customer?> GetByEmailAsync(string email, CancellationToken cToken)
        {
            return await _db.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Email == email, cancellationToken: cToken);
        }

        public async Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cToken)
        {
            return await _db.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == customerId, cancellationToken: cToken);
        }

        public async Task SaveChangesAsync(CancellationToken cToken)
        {
            await _db.SaveChangesAsync(cancellationToken: cToken);
        }

    }
}