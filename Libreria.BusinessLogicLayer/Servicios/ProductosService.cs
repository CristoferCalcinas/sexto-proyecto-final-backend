using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class ProductosService : IProductosService
{
    private readonly IGenericRepository<Producto> _genericRepository;
    public ProductosService(IGenericRepository<Producto> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Producto> AddProducto(Producto producto)
    {
        return await _genericRepository.AddAsync(producto);
    }

    public async Task<Producto> DeleteProducto(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Producto>> GetAllProductos()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Producto> GetProductorById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Producto> UpdateProducto(Producto producto)
    {
        return await _genericRepository.UpdateAsync(producto);
    }
}
