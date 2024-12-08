namespace Libreria.DataAccessLayer.Migracion;

public partial class Rol
{
    public int Id { get; set; }

    public string NombreRol { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
