namespace Libreria.Models;

public partial class PedidoProveedor
{
    public int Id { get; set; }

    public int ProveedorId { get; set; }

    public DateOnly FechaPedido { get; set; }

    public string EstadoPedido { get; set; } = null!;

    public decimal TotalPedido { get; set; }

    public virtual ICollection<DetallePedidoProveedor> DetallePedidoProveedors { get; set; } = new List<DetallePedidoProveedor>();

    public virtual Proveedor Proveedor { get; set; } = null!;
}
