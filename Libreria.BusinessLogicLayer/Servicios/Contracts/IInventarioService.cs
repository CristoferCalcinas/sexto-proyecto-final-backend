using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IInventarioService
{
    Task<Inventario> AddInventario(Inventario inventario);
    Task<Inventario> DeleteInventario(int id);
    Task<Inventario> GetInventarioById(int id);
    Task<Inventario> UpdateInventario(Inventario inventario);
    Task<IQueryable<Inventario>> GetAllInventarios();
}
