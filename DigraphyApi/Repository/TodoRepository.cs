using DigraphyApi.Data;
using DigraphyApi.Models;
using DigraphyApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigraphyApi.Repository;

public class TodoRepository(AppDbContext context) : ITodoRepository
{
    public async Task<ICollection<Todo>> GetTodosAsync()
    {
        return await context.Todos.OrderBy(t => t.Id).ToListAsync();
    }

    public async Task<Todo?> GetTodoAsync(int todoId)
    {
        return await context.Todos.FirstOrDefaultAsync(t => t.Id == todoId);
    }

    public async Task<Todo> UpdateTodoAsync(Todo todo)
    {
        context.Update(todo);
        await context.SaveChangesAsync();
        return todo;
    }

    public async Task<Todo> CreateTodoAsync(Todo todo)
    {
        await context.AddAsync(todo);
        await context.SaveChangesAsync();
        return todo;
    }

    public async Task DeleteTodoAsync(Todo todo)
    {
        context.Remove(todo);
        await context.SaveChangesAsync();
    }

    public async Task<bool> TodoExistsAsync(int todoId)
    {
        return await context.Todos.AnyAsync(t => t.Id == todoId);
    }
}
