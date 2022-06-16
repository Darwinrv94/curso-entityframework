using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(options => options.UseInMemoryDatabase("TareasDb"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) => {
  dbContext.Database.EnsureCreated();

  return Results.Ok("Base de datos " + dbContext.Database.GetDbConnection().ConnectionString);
});

app.Run();
