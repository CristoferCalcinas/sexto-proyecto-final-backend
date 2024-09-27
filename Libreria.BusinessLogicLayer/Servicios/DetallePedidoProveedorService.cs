using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class DetallePedidoProveedorService : IDetallePedidoProveedorService
{
    private readonly IGenericRepository<DetallePedidoProveedor> _genericRepository;
    public DetallePedidoProveedorService(IGenericRepository<DetallePedidoProveedor> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<DetallePedidoProveedor> AddDetallePedidoProveedor(DetallePedidoProveedor detallePedidoProveedor)
    {
        return await _genericRepository.AddAsync(detallePedidoProveedor);
    }

    public async Task<DetallePedidoProveedor> DeleteDetallePedidoProveedor(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<DetallePedidoProveedor>> GetAllDetallePedidoProveedores()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<DetallePedidoProveedor> GetDetallePedidoProveedorById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<DetallePedidoProveedor> UpdateDetallePedidoProveedor(DetallePedidoProveedor detallePedidoProveedor)
    {
        return await _genericRepository.UpdateAsync(detallePedidoProveedor);
    }
}
