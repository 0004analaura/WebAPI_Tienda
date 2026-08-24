using TiendaProductosAPI.Interfaces;
using TiendaProductosAPI.Models;

namespace TiendaProductosAPI.Services
{
    // Esta clase recibe las peticiones del Controller y pide los datos al Repository.
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _productoRepository.ObtenerTodosAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerPorIdAsync(id);
        }
    }
}
