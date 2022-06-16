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
    var categoriasInit = new List<Categoria>();

    categoriasInit.Add(new Categoria {
      CategoriaId = Guid.Parse("8a3d0828-ab86-42b4-9761-92bc5d94908b"),
      Nombre = "Actividades Pendientes",
      Peso = 20
    });

    categoriasInit.Add(new Categoria
    {
      CategoriaId = Guid.Parse("8a3d0828-ab86-42b4-9761-92bc5d949002"),
      Nombre = "Actividades Personales",
      Peso = 50
    });

    modelBuilder.Entity<Categoria>(categoria => {
      categoria.ToTable("Categoria");

      categoria.HasKey(c => c.CategoriaId);
      categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(c => c.Descripcion);
      categoria.Property(c => c.Peso);

      categoria.HasData(categoriasInit);
    });

    var tareasInit = new List<Tarea>();

    tareasInit.Add(new Tarea
    {
      TareaId = Guid.Parse("8a3d0828-ab86-42b4-9761-92bc5d949010"),
      CategoriaId = Guid.Parse("8a3d0828-ab86-42b4-9761-92bc5d94908b"),
      Titulo = "Pago de servicios públicos",
      PrioridadTarea = Prioridad.Media,
      FechaCreacion = DateTime.Now
    });

    tareasInit.Add(new Tarea
    {
      TareaId = Guid.Parse("8a3d0828-ab86-42b4-9761-92bc5d949011"),
      CategoriaId = Guid.Parse("8a3d0828-ab86-42b4-9761-92bc5d949002"),
      Titulo = "Terminar de ver película en Netflix",
      PrioridadTarea = Prioridad.Baja,
      FechaCreacion = DateTime.Now
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

      tarea.HasData(tareasInit);
    });
  }
}
