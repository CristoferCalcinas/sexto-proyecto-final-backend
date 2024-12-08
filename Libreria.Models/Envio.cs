namespace Libreria.DataAccessLayer.Migracion;

public partial class Envio
{
    public int Id { get; set; }

    public int CompraId { get; set; }

    public int SucursalId { get; set; }

    public DateOnly FechaEnvio { get; set; }

    public string EstadoEnvio { get; set; } = null!;

    public virtual Compra Compra { get; set; } = null!;

    public virtual Sucursal Sucursal { get; set; } = null!;
}
