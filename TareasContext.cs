using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto;

public class TareasContext: DbContext
{
  public DbSet<Categoria> Categorias { get; set; } = null!;
  public DbSet<Tarea> Tareas { get; set; } = null!;
  public TareasContext(DbContextOptions<TareasContext> options): base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Categoria>(categoria => {
      categoria.ToTable("Categoria");

      categoria.HasKey(c => c.CategoriaId);
      categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(c => c.Descripcion);
      categoria.Property(c => c.Peso);
    });

    modelBuilder.Entity<Tarea>(tarea => {
      tarea.ToTable("Tarea");

      tarea.HasKey(t => t.TareaId);
      tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
      tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(t => t.Descripcion);
      tarea.Property(t => t.PrioridadTarea);
      tarea.Property(t => t.FechaCreacion);
      tarea.Ignore(t => t.Resumen);
    });
  }
}
