using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(); // ira add o context aos servicos disponibilizando-o para o projeto todo

var app = builder.Build();

app.MapControllers();

app.Run();
