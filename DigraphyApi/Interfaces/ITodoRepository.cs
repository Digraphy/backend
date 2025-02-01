using DigraphyApi.Models;

namespace DigraphyApi.Interfaces;

public interface ITodoRepository
{
    Task<ICollection<Todo>> GetTodosAsync();
    Task<Todo?> GetTodoAsync(int todoId);
    Task<Todo> UpdateTodoAsync(Todo todo);
    Task<Todo> CreateTodoAsync(Todo todo);
    Task DeleteTodoAsync(Todo todo);
    Task<bool> TodoExistsAsync(int todoId);
}
