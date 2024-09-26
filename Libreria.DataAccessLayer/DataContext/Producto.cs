using System;
using System.Collections.Generic;

namespace Libreria.DataAccessLayer.DataContext;

public partial class Producto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string Descripción { get; set; } = null!;

    public decimal Precio { get; set; }

    public int CantidadStock { get; set; }

    public int CategoríaId { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int ProveedorId { get; set; }

    public virtual Categoría Categoría { get; set; } = null!;

    public virtual ICollection<DetalleCarrito> DetalleCarritos { get; set; } = new List<DetalleCarrito>();

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetallePedidoProveedor> DetallePedidoProveedors { get; set; } = new List<DetallePedidoProveedor>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Promocione> Promociones { get; set; } = new List<Promocione>();

    public virtual Proveedor Proveedor { get; set; } = null!;
}
