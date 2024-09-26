namespace Libreria.Models;

public partial class Compra
{
    public int Id { get; set; }

    public DateOnly FechaCompra { get; set; }

    public int ClienteId { get; set; }

    public decimal TotalCompra { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
