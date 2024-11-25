using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CategoriumService : ICategoriumService
{
    private readonly ICategoriumRepository _genericRepository;
    public CategoriumService(ICategoriumRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Categorium> AddCategoría(Categorium categoría)
    {
        return await _genericRepository.AddAsync(categoría);
    }

    public async Task<bool> DeleteAllCategorías(List<int> ids)
    {
        return await _genericRepository.DeleteAllAsync(ids);
    }

    public async Task<Categorium> DeleteCategoría(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Categorium>> GetAllCategorías()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Categorium> GetCategoríaById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Categorium> UpdateCategoría(Categorium categoría)
    {
        return await _genericRepository.UpdateAsync(categoría);
    }
}
