namespace Libreria.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string CorreoElectrónico { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public virtual ICollection<CarritoCompra> CarritoCompras { get; set; } = new List<CarritoCompra>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Cupone> Cupones { get; set; } = new List<Cupone>();
}
