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
    public Task<Proveedor> AddPromocion(Proveedor proveedor)
    {
        return _genericRepository.AddAsync(proveedor);
    }

    public Task<Proveedor> DeletePromocion(int id)
    {
        return _genericRepository.DeleteAsync(id);
    }

    public Task<IQueryable<Proveedor>> GetAllPromociones()
    {
        return _genericRepository.GetAllAsync();
    }

    public Task<Proveedor> GetPromocionById(int id)
    {
        return _genericRepository.GetByIdAsync(id);
    }

    public Task<Proveedor> UpdatePromocion(Proveedor proveedor)
    {
        return _genericRepository.UpdateAsync(proveedor);
    }
}
