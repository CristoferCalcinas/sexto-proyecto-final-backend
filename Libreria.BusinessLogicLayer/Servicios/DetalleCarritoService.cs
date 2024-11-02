using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class DetalleCarritoService : IDetalleCarritoService
{
    private readonly IDetalleCarritoRepository _genericRepository;
    public DetalleCarritoService(IDetalleCarritoRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<DetalleCarrito> AddDetalleCarrito(DetalleCarrito detalleCarrito)
    {
        return await _genericRepository.AddAsync(detalleCarrito);
    }

    public async Task<DetalleCarrito> DeleteDetalleCarrito(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<DetalleCarrito>> GetAllDetalleCarritos()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<DetalleCarrito> GetDetalleCarritoById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<DetalleCarrito> PatchDetalleCarrito(int id, int? cantidad = null)
    {
        return await _genericRepository.PatchDetalleCarritoAsync(id, cantidad);
    }

    public async Task<DetalleCarrito> UpdateDetalleCarrito(DetalleCarrito detalleCarrito)
    {
        return await _genericRepository.UpdateAsync(detalleCarrito);
    }
}
