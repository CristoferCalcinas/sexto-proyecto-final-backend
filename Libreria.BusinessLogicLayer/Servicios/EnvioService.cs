using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class EnvioService : IEnvioService
{
    private readonly IGenericRepository<Envio> _genericRepository;
    public EnvioService(IGenericRepository<Envio> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Envio> AddEnvio(Envio envio)
    {
        return await _genericRepository.AddAsync(envio);
    }

    public async Task<Envio> DeleteEnvio(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Envio>> GetAllEnvios()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Envio> GetEnvioById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Envio> UpdateEnvio(Envio envio)
    {
        return await _genericRepository.UpdateAsync(envio);
    }
}
