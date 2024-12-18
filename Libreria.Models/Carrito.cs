namespace Libreria.Models;

public partial class Carrito
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public string EstadoCarrito { get; set; } = null!;

    public virtual ICollection<DetalleCarrito> DetalleCarritos { get; set; } = new List<DetalleCarrito>();

    public virtual Usuario Usuario { get; set; } = null!;
}
