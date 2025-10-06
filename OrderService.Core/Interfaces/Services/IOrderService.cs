using OrderService.Core.Dtos;
using OrderService.Core.Entities;

namespace OrderService.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task AddAsync(CreateDto.CreateOrderDto orderDto, CancellationToken cToken);
        Task UpdateAsync(Order order, CancellationToken cToken);
        Task DeleteAsync(Order order, CancellationToken cToken);
        Task<Order?> GetByIdAsync(Guid id, CancellationToken cToken);
        Task SaveChangesAsync(CancellationToken cToken);
    }
}