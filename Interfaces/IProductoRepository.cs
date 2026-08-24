using TiendaProductosAPI.Models;

namespace TiendaProductosAPI.Interfaces
{
    // Esta interfaz indica qué consultas se pueden hacer sobre los productos.
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
    }
}
