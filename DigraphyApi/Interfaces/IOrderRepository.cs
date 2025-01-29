using DigraphyApi.Filters;
using DigraphyApi.Models;
using DigraphyApi.Utils;

namespace DigraphyApi.Interfaces;

public interface IOrderRepository
{
    Task<ICollection<Order>> GetOrdersAsync(OrderFilters filters);
    Task<Order?> GetOrderAsync(int orderId);
}