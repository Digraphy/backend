using AutoMapper;
using DigraphyApi.Dto;
using DigraphyApi.Exceptions;
using DigraphyApi.Interfaces;
using DigraphyApi.Models;
using DigraphyApi.Utils;

namespace DigraphyApi.Services;

public class TodoService(ITodoRepository todoRepository, IMapper mapper) : ITodoService
{
    public async Task<Result<ICollection<TodoDto>>> GetTodosAsync()
    {
        var todo = await todoRepository.GetTodosAsync();

        return mapper.Map<List<TodoDto>>(todo);
    }

    public async Task<Result<TodoDto>> GetTodoAsync(int todoId)
    {
        var todo = await todoRepository.GetTodoAsync(todoId);

        if (todo == null)
        {
            return Errors.TodoNotFound(todoId);
        }

        return mapper.Map<TodoDto>(todo);
    }

    public async Task<Result<TodoDto>> UpdateTodoAsync(int todoId, CreateTodoDto todoDto)
    {
        var existingTodo = await todoRepository.GetTodoAsync(todoId);

        if (existingTodo == null)
        {
            return Errors.TodoNotFound(todoId);
        }

        if (!string.IsNullOrEmpty(todoDto.Name))
        {
            existingTodo.Name = todoDto.Name;
        }

        var todo = await todoRepository.UpdateTodoAsync(existingTodo);

        return mapper.Map<TodoDto>(todo);
    }

    public async Task<Result<TodoDto>> CreateTodoAsync(CreateTodoDto createTodoDto)
    {
        var todo = mapper.Map<Todo>(createTodoDto);

        await todoRepository.CreateTodoAsync(todo);

        return mapper.Map<TodoDto>(todo);
    }

    public async Task<Result> DeleteTodoAsync(int todoId)
    {
        var todo = await todoRepository.GetTodoAsync(todoId);
        if (todo != null) await todoRepository.DeleteTodoAsync(todo);
        return Result.Success();
    }

    public async Task<bool> TodoExistsAsync(int todoId)
    {
        return await todoRepository.TodoExistsAsync(todoId);
    }
}
