using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class InventarioService : IInventarioService
{
    private readonly IGenericRepository<Inventario> _genericRepository;
    public InventarioService(IGenericRepository<Inventario> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Inventario> AddInventario(Inventario inventario)
    {
        return await _genericRepository.AddAsync(inventario);
    }

    public async Task<Inventario> DeleteInventario(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Inventario>> GetAllInventarios()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Inventario> GetInventarioById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Inventario> UpdateInventario(Inventario inventario)
    {
        return await _genericRepository.UpdateAsync(inventario);
    }
}
