using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto;

public class TareasContext: DbContext
{
  public DbSet<Categoria> Categorias { get; set; } = null!;
  public DbSet<Tarea> Tareas { get; set; } = null!;
  public TareasContext(DbContextOptions<TareasContext> options): base(options) { }
}
