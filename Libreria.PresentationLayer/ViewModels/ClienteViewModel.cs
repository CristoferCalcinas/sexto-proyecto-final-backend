namespace Libreria.PresentationLayer.ViewModels;

public class ClienteViewModel
{
    public int Id { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string CorreoElectrónico { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }
}
