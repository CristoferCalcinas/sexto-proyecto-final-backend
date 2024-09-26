using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class PromocionesService : IPromocionesService
{
    private readonly IGenericRepository<Promocione> _genericRepository;
    public PromocionesService(IGenericRepository<Promocione> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    
    public async Task<Promocione> AddPromocion(Promocione promocion)
    {
        return await _genericRepository.AddAsync(promocion);
    }

    public async Task<Promocione> DeletePromocion(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Promocione>> GetAllPromociones()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Promocione> GetPromocionById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Promocione> UpdatePromocion(Promocione promocion)
    {
        return await _genericRepository.UpdateAsync(promocion);
    }
}
