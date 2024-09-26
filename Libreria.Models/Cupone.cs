namespace Libreria.Models;

public partial class Cupone
{
    public int Id { get; set; }

    public string CodigoCupon { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public decimal Descuento { get; set; }

    public DateOnly FechaExpiracion { get; set; }

    public string Estado { get; set; } = null!;

    public int ClientesAplicados { get; set; }

    public virtual Cliente ClientesAplicadosNavigation { get; set; } = null!;
}
