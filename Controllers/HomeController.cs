using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
  [HttpGet("/")]
  public IActionResult Get([FromServices] AppDbContext context)
    => Ok(context.Todos.ToList()); // ira ter um return ok - status 200

  
  [HttpGet("/{id:int}")]
  public IActionResult Get
  (
    [FromRoute] int id,
    [FromServices] AppDbContext context
  )
  {
    TodoModel? todo = context.Todos.FirstOrDefault(x => x.Id == id);
    
    return todo == null ? NotFound() : Ok(todo) ;
  }


  [HttpPost("/")]
  public IActionResult Post
  (
    [FromBody] TodoModel todo,
    [FromServices] AppDbContext context
  )
  {
    context.Todos.Add(todo);
    context.SaveChanges();

    return Created($"/{todo.Id}", todo);
  }


  [HttpPut("/{id:int}")]
  public IActionResult Put
  (
    [FromRoute] int id,
    [FromBody] TodoModel todo,
    [FromServices] AppDbContext context
  )
  {
    TodoModel? todoToUpdate = context.Todos.FirstOrDefault(x => x.Id == id);

    if (todoToUpdate == null)
      return NotFound();
    
    todoToUpdate.Title = todo.Title;
    todoToUpdate.Done = todo.Done;

    context.Todos.Update(todoToUpdate);
    context.SaveChanges();

    return Ok(todo);
  }


  [HttpDelete("/{id:int}")]
  public IActionResult Delete
  (
    [FromRoute] int id,
    [FromServices] AppDbContext context
  )
  {
    TodoModel? todoToDelete = context.Todos.FirstOrDefault(x => x.Id == id);

    if (todoToDelete == null)
      return NotFound();
    
    context.Todos.Remove(todoToDelete);
    context.SaveChanges();

    return Ok(todoToDelete);
  }
}
