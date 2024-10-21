using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class SucursalService : ISucursalService
{
    private readonly IGenericRepository<Sucursal> _genericRepository;
    public SucursalService(IGenericRepository<Sucursal> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Sucursal> AddSucursal(Sucursal sucursal)
    {
        return await _genericRepository.AddAsync(sucursal);
    }

    public async Task<Sucursal> DeleteSucursal(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Sucursal>> GetAllSucursal()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Sucursal> GetSucursalById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Sucursal> UpdateSucursal(Sucursal sucursal)
    {
        return await _genericRepository.UpdateAsync(sucursal);
    }

}
