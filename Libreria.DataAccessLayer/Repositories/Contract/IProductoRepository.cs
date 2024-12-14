using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<List<Producto>> SearchProductsByNameAsync(string textSearch);
    Task<List<Producto>> ReduceProductQuantityAsync(List<ReduceProductQuantity> reduceProductQuantity);
}
