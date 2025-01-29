using System.Net;
using DigraphyApi.Utils;

namespace DigraphyApi.Exceptions;

public class Errors
{
    public static class Codes
    {
        public const string TodoNotFound = "Todo.NotFound";
        public const string OrderNotFound = "Order.NotFound";
    }

    public static Error TodoNotFound(int todoId) =>
        new(Codes.TodoNotFound, $"No Todo found for id {todoId}", HttpStatusCode.NotFound);
    
    public static Error OrderNotFound(int orderId) =>
        new(Codes.OrderNotFound, $"No Order found for id {orderId}", HttpStatusCode.NotFound);
}