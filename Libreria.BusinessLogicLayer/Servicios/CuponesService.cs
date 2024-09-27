using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CuponesService : ICuponesService
{
    private readonly IGenericRepository<Cupone> _genericRepository;
    public CuponesService(IGenericRepository<Cupone> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    
    public async Task<Cupone> AddCupon(Cupone cupon)
    {
        return await _genericRepository.AddAsync(cupon);
    }

    public async Task<Cupone> DeleteCupon(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Cupone>> GetAllCupones()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Cupone> GetCuponById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Cupone> UpdateCupon(Cupone cupon)
    {
        return await _genericRepository.UpdateAsync(cupon);
    }
}
