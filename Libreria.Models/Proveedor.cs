namespace Libreria.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Teléfono { get; set; } = null!;

    public string CorreoElectrónico { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<PedidoProveedor> PedidoProveedors { get; set; } = new List<PedidoProveedor>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
