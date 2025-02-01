using System.Net;
using DigraphyApi.Utils;

namespace DigraphyApi.Exceptions;

public class Errors
{
    public static class Codes
    {
        public const string TodoNotFound = "Todo.NotFound";
    }

    public static Error TodoNotFound(int todoId) =>
        new(Codes.TodoNotFound, $"No Todo found for id {todoId}", HttpStatusCode.NotFound);
}
