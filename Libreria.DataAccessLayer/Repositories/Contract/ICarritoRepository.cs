using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface ICarritoRepository : IGenericRepository<Carrito>
{
    Task<List<Carrito>> GetAllWithDetailsAsync(int id);
    Task<Carrito> GetLastCarritoCompraAsync(int clienteId);
}
