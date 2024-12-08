namespace Libreria.DataAccessLayer.Migracion;

public partial class Compra
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public DateOnly FechaCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual Usuario Usuario { get; set; } = null!;
}
