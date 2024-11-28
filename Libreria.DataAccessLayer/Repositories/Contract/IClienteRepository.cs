using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IClienteRepository : IGenericRepository<Cliente>
{
    Task<object> GetByCorreoAsync(string correo);
}
