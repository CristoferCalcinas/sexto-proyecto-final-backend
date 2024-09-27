namespace Libreria.PresentationLayer.ViewModels;

public class DetallePedidoProveedorViewModel
{
    public int Id { get; set; }

    public int PedidoProveedorId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }
}
