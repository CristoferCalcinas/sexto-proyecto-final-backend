namespace Libreria.DataAccessLayer.Migracion;

public partial class Sucursal
{
    public int Id { get; set; }

    public string NombreSucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();
}
