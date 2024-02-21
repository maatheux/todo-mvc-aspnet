var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // ira add os servicos de Controllers

var app = builder.Build();

app.MapControllers(); // ira mapear todas as Controllers do projeto, ira pegar todas as classes que herdam a classe ControllerBase

app.Run();
