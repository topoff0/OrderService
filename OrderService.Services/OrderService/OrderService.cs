using OrderService.Core.Dtos.OrderDtos;
using OrderService.Core.Entities;
using OrderService.Core.Exceptions;
using OrderService.Core.Interfaces.Repositories;
using OrderService.Core.Interfaces.Services;

namespace OrderService.Services.OrderService
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task AddAsync(OrderDto orderDto, CancellationToken cToken)
        {
            await _orderRepository.AddAsync(orderDto, cToken);
            await _orderRepository.SaveChangesAsync(cToken);
        }

        public async Task UpdateAsync(Order order, CancellationToken cToken)
        {
            _orderRepository.Update(order);
            await _orderRepository.SaveChangesAsync(cToken);
        }

        public async Task DeleteAsync(Order order, CancellationToken cToken)
        {
            _orderRepository.Delete(order);
            await _orderRepository.SaveChangesAsync(cToken);
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cToken)
        {
            var order = await _orderRepository.GetByIdAsync(id, cToken);
            if (order is null)
                throw new RecordNotFoundException($"Oder with id:{{{id}}} not found");

            return order;
        }

        public async Task SaveChangesAsync(CancellationToken cToken)
        {
            await _orderRepository.SaveChangesAsync(cToken);
        }

    }
}