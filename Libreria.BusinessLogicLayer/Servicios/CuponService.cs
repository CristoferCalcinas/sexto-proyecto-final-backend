using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CuponService : ICuponService
{
    private readonly IGenericRepository<Cupon> _genericRepository;
    public CuponService(IGenericRepository<Cupon> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    
    public async Task<Cupon> AddCupon(Cupon cupon)
    {
        return await _genericRepository.AddAsync(cupon);
    }

    public async Task<Cupon> DeleteCupon(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Cupon>> GetAllCupones()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Cupon> GetCuponById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Cupon> UpdateCupon(Cupon cupon)
    {
        return await _genericRepository.UpdateAsync(cupon);
    }
}
