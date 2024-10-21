using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CarritoService : ICarritoService
{
    private readonly IGenericRepository<Carrito> _genericRepository;
    public CarritoService(IGenericRepository<Carrito> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Carrito> AddCarritoCompra(Carrito carritoCompra)
    {
        return await _genericRepository.AddAsync(carritoCompra);
    }

    public async Task<Carrito> DeleteCarritoCompra(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Carrito>> GetAllCarritoCompras()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Carrito> GetCarritoCompraById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Carrito> UpdateCarritoCompra(Carrito carritoCompra)
    {
        return await _genericRepository.UpdateAsync(carritoCompra);
    }
}
