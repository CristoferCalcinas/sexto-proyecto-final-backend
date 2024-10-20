namespace Libreria.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public DateOnly FechaContratacion { get; set; }
}
