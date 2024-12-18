namespace Libreria.PresentationLayer.ViewModels;

public class UsuarioViewModel
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Telefono { get; set; }
}
