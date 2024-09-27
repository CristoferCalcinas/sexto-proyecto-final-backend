using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IDetalleCompraService
{
    Task<DetalleCompra> AddDetalleCompra(DetalleCompra detalleCompra);
    Task<DetalleCompra> DeleteDetalleCompra(int id);
    Task<DetalleCompra> GetDetalleCompraById(int id);
    Task<DetalleCompra> UpdateDetalleCompra(DetalleCompra detalleCompra);
    Task<IQueryable<DetalleCompra>> GetAllDetalleCompras();
}
