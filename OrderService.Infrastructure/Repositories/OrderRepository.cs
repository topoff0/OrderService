using Microsoft.EntityFrameworkCore;
using OrderService.Core.Dtos;
using OrderService.Core.Entities;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    public class OrderRepository(ApplicationDbContext db) : IOrderRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<Order> AddAsync(CreateDto.CreateOrderDto orderDto, CancellationToken cToken)
        {
            var order = new Order(orderDto);
            await _db.AddAsync(order, cancellationToken: cToken);
            return order;
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