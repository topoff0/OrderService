using Microsoft.EntityFrameworkCore;
using OrderService.Core.Dtos.OrderDtos;
using OrderService.Core.Entities;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext db) : IOrderRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task AddAsync(OrderDto orderDto, CancellationToken cToken)
        {
            await _db.AddAsync(new Order(orderDto), cancellationToken: cToken);
        }

        public void Update(Order order)
        {
            _db.Update(order);
        }

        public void Delete(Order order)
        {
            _db.Remove(order);
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cToken)
        {
            return await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken: cToken);
        }

        public async Task SaveChangesAsync(CancellationToken cToken)
        {
            await _db.SaveChangesAsync(cancellationToken: cToken);
        }

    }
}