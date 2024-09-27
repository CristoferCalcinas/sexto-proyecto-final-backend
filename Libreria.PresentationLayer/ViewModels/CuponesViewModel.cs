namespace Libreria.PresentationLayer.ViewModels;

public class CuponesViewModel
{
    public int Id { get; set; }

    public string CodigoCupon { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public decimal Descuento { get; set; }

    public DateOnly FechaExpiracion { get; set; }

    public string Estado { get; set; } = null!;
}
