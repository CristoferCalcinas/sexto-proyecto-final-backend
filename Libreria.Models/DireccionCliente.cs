namespace Libreria.Models;

public partial class DireccionCliente
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;
}
