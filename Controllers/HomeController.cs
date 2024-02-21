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
}
