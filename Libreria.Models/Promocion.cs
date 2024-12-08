namespace Libreria.DataAccessLayer.Migracion;

public partial class Promocion
{
    public int Id { get; set; }

    public string NombrePromocion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public decimal Descuento { get; set; }

    public int ProductoId { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
