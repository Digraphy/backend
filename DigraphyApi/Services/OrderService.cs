using AutoMapper;
using DigraphyApi.Dto;
using DigraphyApi.Filters;
using DigraphyApi.Exceptions;
using DigraphyApi.Interfaces;
using DigraphyApi.Utils;

namespace DigraphyApi.Services;

public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
{
    public async Task<Result<ICollection<OrderDto>>> GetOrdersAsync(int? collectionId, bool? isVerified)
    {
        var orders = await orderRepository.GetOrdersAsync(new OrderFilters(collectionId, isVerified));
        return mapper.Map<List<OrderDto>>(orders);
    }

    public async Task<Result<ICollection<TitleDto>>> GetOrderAsync(int orderId)
    {
        var order = await orderRepository.GetOrderAsync(orderId);
        
        if (order == null)
        {
            return Errors.OrderNotFound(orderId);
        }

        var titles = order.Titles.OrderBy(t => t.ReleasedAtUtc).ToList();

        return mapper.Map<List<TitleDto>>(titles);
    }
}