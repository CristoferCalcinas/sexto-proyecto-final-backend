using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario> LoginAsync(string correoElectronico, string password);
    Task<Usuario> ChangeRoleToUserAsync(int usuarioId);
    Task<Usuario> ChangeRoleToEmployeeAsync(int usuarioId);
    Task<Usuario> SetUserInactiveAsync(int usuarioId);
}
