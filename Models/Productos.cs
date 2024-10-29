public class Producto
{
    private int idProducto;
    private string descripcion;
    private int precio;

    public int IdProducto { get; }
    public string Descripcion { get; }
    public int Precio { get; }

    public Producto(int idProducto, string descripcion, int precio)
    {
        this.idProducto = idProducto;
        this.descripcion = descripcion;
        this.precio = precio;
    }
}