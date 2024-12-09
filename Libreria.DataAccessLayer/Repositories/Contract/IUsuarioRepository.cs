using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario> LoginAsync(string correoElectronico, string password);
}
