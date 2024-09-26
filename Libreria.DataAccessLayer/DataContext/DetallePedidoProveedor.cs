using System;
using System.Collections.Generic;

namespace Libreria.DataAccessLayer.DataContext;

public partial class DetallePedidoProveedor
{
    public int Id { get; set; }

    public int PedidoProveedorId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public virtual PedidoProveedor PedidoProveedor { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
