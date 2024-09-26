namespace Libreria.PresentationLayer.ViewModels;

public class PedidoProveedorViewModel
{
    public int Id { get; set; }
    public int ProveedorId { get; set; }
    public DateOnly FechaPedido { get; set; }
    public string EstadoPedido { get; set; } = null!;
    public decimal TotalPedido { get; set; }
}
