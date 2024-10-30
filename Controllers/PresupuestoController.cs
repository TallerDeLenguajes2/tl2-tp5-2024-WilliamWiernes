using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class PresupuestoController : ControllerBase
{
    private readonly PresupuestoRepository presupuestoRepository;

    public PresupuestoController()
    {
        presupuestoRepository = new PresupuestoRepository();
    }

    [HttpPost("api/Presupuesto")]
    public ActionResult CrearPresupuesto([FromBody] Presupuesto nuevoPresupuesto)
    {
        presupuestoRepository.CrearPresupuesto(nuevoPresupuesto);

        return Ok("Producto creado correctamente!");
    }

    [HttpPost("api/Presupuesto/{idPresupuesto}/ProductoDetalle")]
    public ActionResult AgregarPresupuestoDetalle(int idPresupuesto, [FromBody] PresupuestoDetalle nuevoPresupuestoDetalle)
    {
        try
        {
            presupuestoRepository.AgregarPresupuestoDetalle(idPresupuesto, nuevoPresupuestoDetalle);

            return Ok("Presupuesto detalle agregado correctamente!");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Presupuesto con id {idPresupuesto} no encontrado! ERROR: {e.Message}");
        }
    }

    [HttpGet("api/Presupuesto")]
    public ActionResult GetPresupuestos()
    {
        var listaPresupuestos = presupuestoRepository.ListarPresupuestos();

        if (listaPresupuestos == null)
            return BadRequest("Lista de presupuestos vacía.");

        return Ok(listaPresupuestos);
    }
}