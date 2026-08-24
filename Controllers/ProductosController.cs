using Microsoft.AspNetCore.Mvc;
using TiendaProductosAPI.Interfaces;

namespace TiendaProductosAPI.Controllers
{
    // Esta clase recibe las peticiones HTTP y responde al usuario.
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET /api/productos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var productos = await _productoService.ObtenerTodosAsync();
            return Ok(productos);
        }

        // GET /api/productos/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { mensaje = "El ID del producto debe ser mayor que cero." });
            }

            var producto = await _productoService.ObtenerPorIdAsync(id);

            // Si no existe un producto con ese ID, se informa al usuario.
            if (producto is null)
            {
                return NotFound(new { mensaje = $"No se encontró un producto con el ID {id}." });
            }

            return Ok(producto);
        }
    }
}
