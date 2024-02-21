using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
  [HttpGet("/")]
  public IList<TodoModel> Get
  (
    [FromServices] AppDbContext context /* pegando o context dos servicos (injecao de dependecia) */
  )
  {
    return context.Todos.ToList();
  }

  [HttpGet("/{id:int}")]
  public TodoModel? Get
  (
    [FromRoute] int id,
    [FromServices] AppDbContext context
  )
  {
    return context.Todos.FirstOrDefault(x => x.Id == id);
  }

  [HttpPost("/")]
  public TodoModel Post
  (
    [FromBody] TodoModel todo,
    [FromServices] AppDbContext context
  )
  {
    context.Todos.Add(todo);
    context.SaveChanges();

    return todo;
  }

  [HttpPut("/{id:int}")]
  public TodoModel Put
  (
    [FromRoute] int id,
    [FromBody] TodoModel todo,
    [FromServices] AppDbContext context
  )
  {
    TodoModel? todoToUpdate = context.Todos.FirstOrDefault(x => x.Id == id);

    if (todoToUpdate == null)
      return todo;
    
    todoToUpdate.Title = todo.Title;
    todoToUpdate.Done = todo.Done;

    context.Todos.Update(todoToUpdate);
    context.SaveChanges();

    return todo;
  }

  [HttpDelete("/{id:int}")]
  public TodoModel? Delete
  (
    [FromRoute] int id,
    [FromServices] AppDbContext context
  )
  {
    TodoModel? todoToDelete = context.Todos.FirstOrDefault(x => x.Id == id);

    if (todoToDelete == null)
      return null;
    
    context.Todos.Remove(todoToDelete);
    context.SaveChanges();

    return todoToDelete;
  }
}
