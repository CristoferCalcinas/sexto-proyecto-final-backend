namespace Libreria.Models;

public partial class Cupon
{
    public int Id { get; set; }

    public string CodigoCupon { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Descuento { get; set; }

    public DateOnly FechaExpiracion { get; set; }

    public string Estado { get; set; } = null!;
}
