using Libreria.Models;

namespace Libreria.DataAccessLayer.Repositories.Contract;

public interface IDetalleCarritoRepository : IGenericRepository<DetalleCarrito>
{
    Task<DetalleCarrito> PatchDetalleCarritoAsync(int id, int? cantidad = null);
}
