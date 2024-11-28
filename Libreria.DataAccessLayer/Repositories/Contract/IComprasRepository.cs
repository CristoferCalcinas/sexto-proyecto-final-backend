using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IComprasRepository : IGenericRepository<Compra>
{
    Task<object> AddDetalleCompraAsync(DetalleCompra detalleCompra);
}