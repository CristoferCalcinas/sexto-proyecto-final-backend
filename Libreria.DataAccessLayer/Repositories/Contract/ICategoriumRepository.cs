using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface ICategoriumRepository : IGenericRepository<Categorium>
{
    Task<bool> DeleteAllAsync(List<int> ids);
}
