using TiendaProductosAPI.Models;

namespace TiendaProductosAPI.Interfaces
{
    // Esta interfaz define las operaciones que el Controller puede solicitar.
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto?> ObtenerPorIdAsync(int id);
    }
}
