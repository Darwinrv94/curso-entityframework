using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto;
using proyecto.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDb"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) => {
  dbContext.Database.EnsureCreated();

  return Results.Ok("Base de datos " + dbContext.Database.GetDbConnection().ConnectionString);
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => {
  var tareas = await dbContext.Tareas.Include(t => t.Categoria).ToListAsync();

  return Results.Ok(tareas);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  tarea.TareaId = Guid.NewGuid();
  tarea.CategoriaId = tarea.CategoriaId;
  tarea.FechaCreacion = DateTime.Now;

  await dbContext.Tareas.AddAsync(tarea);
  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
  var tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual == null)
    return Results.NotFound("No se encontró la tarea");

  tareaActual.CategoriaId = tarea.CategoriaId;
  tareaActual.Titulo = tarea.Titulo;
  tareaActual.PrioridadTarea = tarea.PrioridadTarea;
  tareaActual.Descripcion = tarea.Descripcion;
  tareaActual.FechaCreacion = DateTime.Now;

  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
  var tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual == null)
    return Results.NotFound("No se encontró la tarea");

  dbContext.Remove<Tarea>(tareaActual);
  await dbContext.SaveChangesAsync();

  return Results.Ok();
});

app.Run();
