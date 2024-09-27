using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IClienteService
{
    Task<Cliente> AddCliente(Cliente cliente);
    Task<Cliente> DeleteCliente(int id);
    Task<IQueryable<Cliente>> GetAllClientes();
    Task<Cliente> GetClienteById(int id);
    Task<Cliente> UpdateCliente(Cliente cliente);
}
