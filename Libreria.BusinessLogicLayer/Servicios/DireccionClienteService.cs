using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class DireccionClienteService : IDireccionClienteService
{
    private readonly IGenericRepository<DireccionCliente> _genericRepository;
    public DireccionClienteService(IGenericRepository<DireccionCliente> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<DireccionCliente> AddDireccionCliente(DireccionCliente direccionCliente)
    {
        return await _genericRepository.AddAsync(direccionCliente);
    }

    public async Task<DireccionCliente> DeleteDireccionCliente(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<DireccionCliente>> GetAllDireccionCliente()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<DireccionCliente> GetDireccionClienteById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<DireccionCliente> UpdateDireccionCliente(DireccionCliente direccionCliente)
    {
        return await _genericRepository.UpdateAsync(direccionCliente);
    }
}
