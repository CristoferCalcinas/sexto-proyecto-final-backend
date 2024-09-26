using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class ProveedorService : IProveedorService
{
    private readonly IGenericRepository<Proveedor> _genericRepository;
    public ProveedorService(IGenericRepository<Proveedor> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Proveedor> AddProveedor(Proveedor proveedor)
    {
        return await _genericRepository.AddAsync(proveedor);
    }

    public async Task<Proveedor> DeleteProveedor(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Proveedor>> GetAllProveedores()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Proveedor> GetProveedorById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public Task<Proveedor> UpdateProveedor(Proveedor proveedor)
    {
        return _genericRepository.UpdateAsync(proveedor);
    }
}
