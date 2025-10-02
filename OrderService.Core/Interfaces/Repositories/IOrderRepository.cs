using OrderService.Core.Dtos.OrderDtos;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task AddAsync(OrderDto orderDto);
        public void Update(Order order);
        public void Delete(Order order);
        public Task<Order?> GetByIdAsync(Guid id);
        public Task SaveChangesAsync();
    }
}