using Microsoft.EntityFrameworkCore;
using TiendaProductosAPI.Data;
using TiendaProductosAPI.Interfaces;
using TiendaProductosAPI.Models;

namespace TiendaProductosAPI.Repositories
{
    // Esta clase se encarga únicamente de consultar la base de datos.
    public class ProductoRepository : IProductoRepository
    {
        private readonly TiendaDbContext _contexto;

        public ProductoRepository(TiendaDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            // Aquí se solicitan los productos almacenados en la base de datos.
            return await _contexto.Productos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _contexto.Productos
                .AsNoTracking()
                .FirstOrDefaultAsync(producto => producto.Id == id);
        }
    }
}
