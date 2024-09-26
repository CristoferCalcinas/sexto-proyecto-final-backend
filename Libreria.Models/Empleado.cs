namespace Libreria.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string CorreoElectrónico { get; set; } = null!;

    public string Teléfono { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public DateOnly FechaContratación { get; set; }
}
