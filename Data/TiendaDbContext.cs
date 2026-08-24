using Microsoft.EntityFrameworkCore;
using TiendaProductosAPI.Models;

namespace TiendaProductosAPI.Data
{
    // Esta clase permite que Entity Framework se comunique con SQL Server.
    public class TiendaDbContext : DbContext
    {
        public TiendaDbContext(DbContextOptions<TiendaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Se define cómo se guarda el precio en SQL Server.
            modelBuilder.Entity<Producto>(entidad =>
            {
                entidad.Property(producto => producto.Precio)
                    .HasColumnType("decimal(10,2)");
            });

            // Se agregan productos iniciales para poder probar la API.
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Laptop HP 15",
                    Precio = 5499.99m,
                    Stock = 12
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Mouse inalámbrico",
                    Precio = 129.50m,
                    Stock = 45
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Teclado mecánico",
                    Precio = 389.00m,
                    Stock = 20
                },
                new Producto
                {
                    Id = 4,
                    Nombre = "Monitor 24 pulgadas",
                    Precio = 1899.90m,
                    Stock = 8
                },
                new Producto
                {
                    Id = 5,
                    Nombre = "Audífonos Bluetooth",
                    Precio = 249.75m,
                    Stock = 30
                }
            );
        }
    }
}
