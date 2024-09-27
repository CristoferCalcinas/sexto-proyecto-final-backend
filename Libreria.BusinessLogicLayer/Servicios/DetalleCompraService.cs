using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class DetalleCompraService : IDetalleCompraService
{
    private readonly IGenericRepository<DetalleCompra> _genericRepository;
    public DetalleCompraService(IGenericRepository<DetalleCompra> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<DetalleCompra> AddDetalleCompra(DetalleCompra detalleCompra)
    {
        return await _genericRepository.AddAsync(detalleCompra);
    }

    public async Task<DetalleCompra> DeleteDetalleCompra(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<DetalleCompra>> GetAllDetalleCompras()
    {
        return await _genericRepository.GetAllAsync();        
    }

    public async Task<DetalleCompra> GetDetalleCompraById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<DetalleCompra> UpdateDetalleCompra(DetalleCompra detalleCompra)
    {
        return await _genericRepository.UpdateAsync(detalleCompra);
    }
}
