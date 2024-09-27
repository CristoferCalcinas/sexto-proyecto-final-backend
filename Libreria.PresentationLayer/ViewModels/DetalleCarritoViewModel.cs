namespace Libreria.PresentationLayer.ViewModels;

public class DetalleCarritoViewModel
{
    public int Id { get; set; }

    public int CarritoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }
}
