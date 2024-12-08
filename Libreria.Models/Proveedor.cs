namespace Libreria.DataAccessLayer.Migracion;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Telefono { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<PedidoProveedor> PedidoProveedors { get; set; } = new List<PedidoProveedor>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
