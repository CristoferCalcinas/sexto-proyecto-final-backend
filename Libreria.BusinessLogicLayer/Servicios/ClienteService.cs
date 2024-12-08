using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _genericRepository;
    public ClienteService(IClienteRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Cliente> AddCliente(Cliente cliente)
    {
        return await _genericRepository.AddAsync(cliente);
    }

    public async Task<Cliente> DeleteCliente(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Cliente>> GetAllClientes()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<object> GetClienteByCorreo(string correo)
    {
        return await _genericRepository.GetByCorreoAsync(correo);
    }

    public async Task<Cliente> GetClienteById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Cliente> UpdateCliente(Cliente cliente)
    {
        return await _genericRepository.UpdateAsync(cliente);
    }
}
