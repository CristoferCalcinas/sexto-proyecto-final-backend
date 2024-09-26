namespace Libreria.Models;

public partial class Promocione
{
    public int Id { get; set; }

    public string NombrePromocion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal Descuento { get; set; }

    public int ProductosAplicados { get; set; }

    public virtual Producto ProductosAplicadosNavigation { get; set; } = null!;
}
