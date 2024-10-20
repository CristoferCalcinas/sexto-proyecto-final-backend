namespace Libreria.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<DireccionCliente> DireccionClientes { get; set; } = new List<DireccionCliente>();
}
