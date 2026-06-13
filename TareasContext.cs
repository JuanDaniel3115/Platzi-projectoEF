using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;

namespace proyectoEF
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("4af1c509-cef6-42a9-9b33-a58914e94446"),
                Nombre = "Actividades Pendientes",
                Peso = 20
            });
            categoriasInit.Add(new Categoria()
            {
                CategoriaId = Guid.Parse("4af1c509-cef6-42a9-9b33-a58914e94402"),
                Nombre = "Actividades personales",
                Peso = 50
            });
            //!Fluent API
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(500);
                categoria.Property(p => p.Peso);

                //insertar datos iniciales
                categoria.HasData(categoriasInit);

            });

            modelBuilder.Entity<Tarea>(tarea =>
            {

                List<Tarea> tareasInit = new List<Tarea>();
                tareasInit.Add(new Tarea()
                {
                    TareaId = Guid.Parse("4af1c509-cef6-42a9-9b33-a58914e94410"),
                    CategoriaId = Guid.Parse("4af1c509-cef6-42a9-9b33-a58914e94446"),
                    Titulo = "Pago de servicios publicos",
                    Descripcion = "Pagar el agua y la luz antes del 5 de cada mes",
                    PrioridadTarea = PrioridadTarea.Media,
                    FechaCreacion = new DateTime(2026, 6, 8),
                    Puntos = 50
                });
                    tareasInit.Add(new Tarea()
                {
                    TareaId = Guid.Parse("4af1c509-cef6-42a9-9b33-a58914e94411"),
                    CategoriaId = Guid.Parse("4af1c509-cef6-42a9-9b33-a58914e94402"),
                    Titulo = "Pago de servicios publicos",
                    Descripcion = "Terminar de ver la serie de netflix",
                    PrioridadTarea = PrioridadTarea.Baja,
                    FechaCreacion = new DateTime(2026, 6, 8),
                    Puntos = 20
                });

                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);

                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(300);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Property(p => p.FechaCreacion);
                tarea.Property(p => p.Puntos);

                tarea.Ignore(p => p.Resumen);

                //insertar datos iniciales
                tarea.HasData(tareasInit);
            });
        }
    }
}