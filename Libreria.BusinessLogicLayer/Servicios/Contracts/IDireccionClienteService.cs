using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IDireccionClienteService
{
    Task<DireccionCliente> AddDireccionCliente(DireccionCliente direccionCliente);
    Task<DireccionCliente> DeleteDireccionCliente(int id);
    Task<IQueryable<DireccionCliente>> GetAllDireccionCliente();
    Task<DireccionCliente> GetDireccionClienteById(int id);
    Task<DireccionCliente> UpdateDireccionCliente(DireccionCliente direccionCliente);
}
