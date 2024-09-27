namespace Libreria.PresentationLayer.ViewModels;

public class InventarioViewModel
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int CantidadEntrante { get; set; }

    public DateOnly FechaEntrada { get; set; }
}