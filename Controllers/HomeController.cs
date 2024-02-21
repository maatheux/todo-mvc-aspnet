using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
  [HttpGet("/")] /* Por default, se nao colocar nenhum atributo, a controller ira entender que eh um Get */
  // [Route("/")] /* A rota que essa action sera chamada // mas eh possivel ja definir a rota no atributo do tipo do metodo */
  public string Get()
  {
    return "Hello World";
  } // os metodos em uma controller podem ser chamados de 'Actions'
}
// Pode herdar da classe Controller ou de ControllerBase (mais recomendado para APIs)
