namespace Libreria.PresentationLayer.ViewModels;

public class CarritoCompraViewModel
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public DateOnly FechaCreación { get; set; }

    public string EstadoCarrito { get; set; } = null!;
}
