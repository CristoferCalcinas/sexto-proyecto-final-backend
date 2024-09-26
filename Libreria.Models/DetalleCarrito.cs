namespace Libreria.Models;

public partial class DetalleCarrito
{
    public int Id { get; set; }

    public int CarritoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual CarritoCompra Carrito { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
