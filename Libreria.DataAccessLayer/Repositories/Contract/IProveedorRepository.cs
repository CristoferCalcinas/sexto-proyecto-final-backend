using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IProveedorRepository : IGenericRepository<Proveedor>
{
    Task<bool> DeleteAllAsync(List<int> ids);
}
