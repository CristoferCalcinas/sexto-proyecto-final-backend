using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IProveedorService
{
    Task<IQueryable<Proveedor>> GetAllPromociones();
    Task<Proveedor> GetPromocionById(int id);
    Task<Proveedor> AddPromocion(Proveedor proveedor);
    Task<Proveedor> DeletePromocion(int id);
    Task<Proveedor> UpdatePromocion(Proveedor proveedor);
}
