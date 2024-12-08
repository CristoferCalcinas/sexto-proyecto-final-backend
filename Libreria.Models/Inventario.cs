namespace Libreria.Models;

public partial class Inventario
{
    public int Id { get; set; }

    public int ProductoId { get; set; }

    public int CantidadEntrante { get; set; }

    public DateOnly FechaEntrada { get; set; }

    public int ProveedorId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Proveedor Proveedor { get; set; } = null!;
}
