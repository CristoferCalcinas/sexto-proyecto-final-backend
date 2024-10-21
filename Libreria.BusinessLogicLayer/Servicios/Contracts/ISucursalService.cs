using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ISucursalService
{
    Task<Sucursal> AddSucursal(Sucursal sucursal);
    Task<Sucursal> DeleteSucursal(int id);
    Task<IQueryable<Sucursal>> GetAllSucursal();
    Task<Sucursal> GetSucursalById(int id);
    Task<Sucursal> UpdateSucursal(Sucursal sucursal);
}
