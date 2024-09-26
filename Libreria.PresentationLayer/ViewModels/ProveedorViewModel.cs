namespace Libreria.PresentationLayer.ViewModels;

public class ProveedorViewModel
{
    public int Id { get; set; }

    public string Teléfono { get; set; } = null!;

    public string CorreoElectrónico { get; set; } = null!;

    public string Dirección { get; set; } = null!;
}