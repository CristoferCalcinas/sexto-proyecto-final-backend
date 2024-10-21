using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class PromocionService : IPromocionService
{
    private readonly IGenericRepository<Promocion> _genericRepository;
    public PromocionService(IGenericRepository<Promocion> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    
    public async Task<Promocion> AddPromocion(Promocion promocion)
    {
        return await _genericRepository.AddAsync(promocion);
    }

    public async Task<Promocion> DeletePromocion(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Promocion>> GetAllPromociones()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Promocion> GetPromocionById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Promocion> UpdatePromocion(Promocion promocion)
    {
        return await _genericRepository.UpdateAsync(promocion);
    }
}
