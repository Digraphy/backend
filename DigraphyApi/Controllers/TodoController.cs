using DigraphyApi.Dto;
using DigraphyApi.Models;
using DigraphyApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigraphyApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController(ITodoService todoService) : Controller
{
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Todo>))]
    public async Task<ActionResult<List<TodoDto>>> GetTodos()
    {
        var todosResult = await todoService.GetTodosAsync();
        var todosDto = todosResult.Data;
        return Ok(todosDto);
    }

    [HttpGet("{todoId}")]
    [ProducesResponseType(200, Type = typeof(Todo))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<TodoDto>> GetTodo(int todoId)
    {
        var todoResult = await todoService.GetTodoAsync(todoId);
        var todoDto = todoResult.Data;
        return Ok(todoDto);
    }

    [HttpPut("{todoId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<TodoDto>> UpdateTodo(int todoId,
        [FromBody] CreateTodoDto updatedTodo)
    {
        var todoResult = await todoService.UpdateTodoAsync(todoId, updatedTodo);
        return todoResult.ToActionResult(Ok);
    }

    [HttpPost("/todo")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto createTodoDto)
    {
        var todoResult = await todoService.CreateTodoAsync(createTodoDto);
        return todoResult.ToActionResult(todo => CreatedAtAction(nameof(GetTodo), new { todoId = todo.Id }, todo));
    }

    [HttpDelete("{todoId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteTodo(int todoId)
    {
        var todoResult = await todoService.DeleteTodoAsync(todoId);
        return todoResult.ToActionResult(NoContent);
    }
}
