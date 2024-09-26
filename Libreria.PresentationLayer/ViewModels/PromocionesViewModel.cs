namespace Libreria.PresentationLayer.ViewModels;

public class PromocionesViewModel
{
    public int Id { get; set; }

    public string NombrePromocion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal Descuento { get; set; }
}