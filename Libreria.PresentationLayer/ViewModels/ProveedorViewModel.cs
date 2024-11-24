namespace Libreria.PresentationLayer.ViewModels;

public class ProveedorViewModel
{
    public int Id { get; set; }

    public string Telefono { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}