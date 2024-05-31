using Matheus.models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Prova A2 em dupla!");


app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
  ctx.Funcionarios.Add(funcionario);
  ctx.SaveChanges();
  return Results.Created($"/api/funcionario/{funcionario.Id}", funcionario);
});

app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    return Results.Ok(ctx.Funcionarios.ToList());
});

app.Run();
