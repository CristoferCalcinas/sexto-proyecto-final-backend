using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CategoríaService : ICategoríaService
{
    private readonly IGenericRepository<Categoría> _genericRepository;
    public CategoríaService(IGenericRepository<Categoría> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Categoría> AddCategoría(Categoría categoría)
    {
        return await _genericRepository.AddAsync(categoría);
    }

    public async Task<Categoría> DeleteCategoría(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Categoría>> GetAllCategorías()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Categoría> GetCategoríaById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Categoría> UpdateCategoría(Categoría categoría)
    {
        return await _genericRepository.UpdateAsync(categoría);
    }
}
