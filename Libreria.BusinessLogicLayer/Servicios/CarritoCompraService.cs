using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class CarritoCompraService : ICarritoCompraService
{
    private readonly IGenericRepository<CarritoCompra> _genericRepository;
    public CarritoCompraService(IGenericRepository<CarritoCompra> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<CarritoCompra> AddCarritoCompra(CarritoCompra carritoCompra)
    {
        return await _genericRepository.AddAsync(carritoCompra);
    }

    public async Task<CarritoCompra> DeleteCarritoCompra(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<CarritoCompra>> GetAllCarritoCompras()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<CarritoCompra> GetCarritoCompraById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<CarritoCompra> UpdateCarritoCompra(CarritoCompra carritoCompra)
    {
        return await _genericRepository.UpdateAsync(carritoCompra);
    }
}
