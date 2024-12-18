using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class ProductosService : IProductosService
{
    private readonly IProductoRepository _genericRepository;
    public ProductosService(IProductoRepository genericRepository)
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

    public async Task<List<Producto>> GetProductosByName(string nameProduct)
    {
        return await _genericRepository.SearchProductsByNameAsync(nameProduct);
    }

    public async Task<List<Producto>> ReduceProductQuantity(List<ReduceProductQuantity> reduceProductQuantity, int usuarioId)
    {
        return await _genericRepository.ReduceProductQuantityAsync(reduceProductQuantity, usuarioId);
    }

    public async Task<Producto> UpdateProducto(Producto producto)
    {
        return await _genericRepository.UpdateAsync(producto);
    }
}
