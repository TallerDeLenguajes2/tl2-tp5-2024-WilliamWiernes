public class PresupuestoDetalle
{
    private Producto producto;
    private int cantidad;

    public Producto Producto { get; }
    public int Cantidad { get; }

    public PresupuestoDetalle(Producto producto, int cantidad)
    {
        this.producto = producto;
        this.cantidad = cantidad;
    }
}