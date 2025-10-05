using OrderService.Core.Dtos;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(CreateDtos.CreateOrderDto orderDto, CancellationToken cToken);
        void Update(Order order);
        void Delete(Order order);
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cToken);
        Task SaveChangesAsync(CancellationToken cToken);
    }
}