using DigraphyApi.Dto;
using DigraphyApi.Models;
using DigraphyApi.Utils;

namespace DigraphyApi.Interfaces;

public interface ITodoService
{
    Task<Result<ICollection<TodoDto>>> GetTodosAsync();
    Task<Result<TodoDto>> GetTodoAsync(int todoId);
    Task<Result<TodoDto>> UpdateTodoAsync(int todoId, CreateTodoDto todo);
    Task<Result<TodoDto>> CreateTodoAsync(CreateTodoDto createTodoDto);
    Task<Result> DeleteTodoAsync(int todoId);
    Task<bool> TodoExistsAsync(int todoId);
}
