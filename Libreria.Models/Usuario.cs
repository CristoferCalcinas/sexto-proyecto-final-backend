namespace Libreria.DataAccessLayer.Migracion;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int RolId { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public string Telefono { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Rol Rol { get; set; } = null!;
}
