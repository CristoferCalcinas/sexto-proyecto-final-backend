using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CarritoService : ICarritoService
{
    private readonly ICarritoRepository _genericRepository;
    public CarritoService(ICarritoRepository genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Carrito> AddCarritoCompra(Carrito carritoCompra)
    {
        return await _genericRepository.AddAsync(carritoCompra);
    }

    public Task<Carrito> ChangeStateCarritoCompra(int carritoId)
    {
        string estado = "Finalizado";
        return _genericRepository.ChangeStateCarritoCompraAsync(carritoId, estado);
    }

    public async Task<Carrito> DeleteCarritoCompra(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Carrito>> GetAllCarritoCompras()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<List<Carrito>> GetAllWithDetailsCarritoCompras(int id)
    {
        return await _genericRepository.GetAllWithDetailsAsync(id);
    }

    public async Task<Carrito> GetCarritoCompraById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Carrito> GetLastCarritoCompra(int clienteId)
    {
        return await _genericRepository.GetLastCarritoCompraAsync(clienteId);
    }

    public async Task<Carrito> UpdateCarritoCompra(Carrito carritoCompra)
    {
        return await _genericRepository.UpdateAsync(carritoCompra);
    }
}
