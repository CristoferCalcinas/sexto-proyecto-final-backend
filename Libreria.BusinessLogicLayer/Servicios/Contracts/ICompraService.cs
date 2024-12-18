using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICompraService
{
    Task<Compra> AddCompra(Compra compra);
    Task<Compra> DeleteCompra(int id);
    Task<IQueryable<Compra>> GetAllCompras();
    Task<Compra> GetCompraById(int id);
    Task<Compra> UpdateCompra(Compra compra);
    Task<object> AddDetalleCompra(DetalleCompra detalleCompra);
    Task<Producto> GetProduct(int productoId);
    Task<List<Compra>> GetComprasAndDetailsByUser(int userId);
}
