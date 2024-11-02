using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IDetalleCarritoService
{
    Task<DetalleCarrito> AddDetalleCarrito(DetalleCarrito detalleCarrito);
    Task<DetalleCarrito> DeleteDetalleCarrito(int id);
    Task<IQueryable<DetalleCarrito>> GetAllDetalleCarritos();
    Task<DetalleCarrito> GetDetalleCarritoById(int id);
    Task<DetalleCarrito> UpdateDetalleCarrito(DetalleCarrito detalleCarrito);
    Task<DetalleCarrito> PatchDetalleCarrito(int id, int? cantidad = null);
}
