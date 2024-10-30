using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductoRepository productoRepository;

    public ProductoController()
    {
        productoRepository = new ProductoRepository();
    }

    [HttpPost("api/Producto")]
    public ActionResult CrearProducto([FromBody] Producto nuevoProducto)
    {
        productoRepository.CrearProducto(nuevoProducto);

        return Ok("Producto creado correctamente!");
    }

    [HttpGet("api/Producto")]
    public ActionResult GetProductos()
    {
        var listaProductos = productoRepository.ListarProductos();

        if (listaProductos == null)
            return BadRequest("Lista de productos vacía.");

        return Ok(listaProductos);
    }

    [HttpPut("api/Producto/{id},{nuevaDescripcionProducto}")]
    public ActionResult ModificarProducto(int id, string nuevaDescripcionProducto)
    {
        try
        {
            var modProducto = productoRepository.ObtenerDetalles(id);

            modProducto.Descripcion = nuevaDescripcionProducto;

            productoRepository.ModificarProducto(id, modProducto);

            return Ok("Producto modificado correctamente!");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Producto con id {id} no encontrado! ERROR: {e.Message}");
        }
    }
}