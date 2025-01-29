using DigraphyApi.Dto;
using DigraphyApi.Utils;

namespace DigraphyApi.Interfaces;

public interface IOrderService
{
    Task<Result<ICollection<OrderDto>>> GetOrdersAsync(int? collectionId, bool? isVerified);
    
    Task<Result<ICollection<TitleDto>>> GetOrderAsync(int orderId);
}