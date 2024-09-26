using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IProveedorService
{
    Task<IQueryable<Proveedor>> GetAllProveedores();
    Task<Proveedor> AddProveedor(Proveedor proveedor);
    Task<Proveedor> DeleteProveedor(int id);
    Task<Proveedor> GetProveedorById(int id);
    Task<Proveedor> UpdateProveedor(Proveedor proveedor);
}
