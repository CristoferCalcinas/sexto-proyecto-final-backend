using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class PedidoProveedorService : IPedidoProveedorService
{
    private readonly IGenericRepository<PedidoProveedor> _genericRepository;
    public PedidoProveedorService(IGenericRepository<PedidoProveedor> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<PedidoProveedor> AddPedidoProveedor(PedidoProveedor pedidoProveedor)
    {
        return await _genericRepository.AddAsync(pedidoProveedor);
    }

    public async Task<PedidoProveedor> DeletePedidoProveedor(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<PedidoProveedor>> GetAllPedidoProveedor()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<PedidoProveedor> GetPedidoProveedorById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<PedidoProveedor> UpdatePedidoProveedor(PedidoProveedor pedidoProveedor)
    {
        return await _genericRepository.UpdateAsync(pedidoProveedor);
    }
}
