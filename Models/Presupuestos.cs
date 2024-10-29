public class Presupuesto
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private string fechaCreacion;
    private List<PresupuestoDetalle> listaDetalles;

    public int IdPresupuesto { get; }
    public string NombreDestinatario { get; }
    public string FechaCreacion { get; }
    public List<PresupuestoDetalle> ListaDetalles { get; }

    public Presupuesto(int idPresupuesto, string nombreDestinatario, string fechaCreacion)
    {
        this.idPresupuesto = idPresupuesto;
        this.nombreDestinatario = nombreDestinatario;
        this.fechaCreacion = fechaCreacion;
        listaDetalles = new List<PresupuestoDetalle>();
    }

    public int MontoPresupuesto()
    {
        return listaDetalles.Sum(detalle => detalle.Producto.Precio * detalle.Cantidad);
    }

    public int MontoPresupuestoConIva()
    {
        return (int)(MontoPresupuesto() * 0.21);
    }

    public int CantidadProductos()
    {
        return listaDetalles.Sum(detalle => detalle.Cantidad);
    }
}