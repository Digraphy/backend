using DigraphyApi.Data;
using DigraphyApi.Filters;
using DigraphyApi.Interfaces;
using DigraphyApi.Models;
using DigraphyApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace DigraphyApi.Repository;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<ICollection<Order>> GetOrdersAsync(OrderFilters filters)
    {
        IQueryable<Order> query = context.Orders;

        if (filters.CollectionId != null)
        {
            query = query.Where(o => o.Collection.Id == filters.CollectionId);
        }
        if (filters.Verified != null)
        {
            query = query.Where(o => o.IsVerified == filters.Verified);
        }
        return await query.OrderBy(o => o.Id).ToListAsync();
    }

    public async Task<Order?> GetOrderAsync(int orderId)
    {
        return await context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
    }
}