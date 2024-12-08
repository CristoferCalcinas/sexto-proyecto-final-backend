namespace Libreria.DataAccessLayer.Migracion;

public partial class Producto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int CantidadStock { get; set; }

    public int CategoriaId { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int ProveedorId { get; set; }

    public virtual Categorium Categoria { get; set; } = null!;

    public virtual ICollection<DetalleCarrito> DetalleCarritos { get; set; } = new List<DetalleCarrito>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetallePedidoProveedor> DetallePedidoProveedors { get; set; } = new List<DetallePedidoProveedor>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Promocion> Promocions { get; set; } = new List<Promocion>();

    public virtual Proveedor Proveedor { get; set; } = null!;
}
