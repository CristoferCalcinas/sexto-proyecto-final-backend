namespace Libreria.PresentationLayer.ViewModels;

public class EmpleadoViewModel
{
    public int Id { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string CorreoElectrónico { get; set; } = null!;

    public string Teléfono { get; set; } = null!;

    public string Cargo { get; set; } = null!;
}
