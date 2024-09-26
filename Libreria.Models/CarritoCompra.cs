namespace Libreria.Models;

public partial class CarritoCompra
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public DateOnly FechaCreación { get; set; }

    public string EstadoCarrito { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleCarrito> DetalleCarritos { get; set; } = new List<DetalleCarrito>();
}
