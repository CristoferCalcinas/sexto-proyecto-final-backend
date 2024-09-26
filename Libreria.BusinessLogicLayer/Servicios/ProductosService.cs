using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class ProductosService : IProductosService
{
    private readonly IProductosService _service;
    public ProductosService(IProductosService service)
    {
        _service = service;
    }
    public async Task<Producto> AddProducto(Producto proveedor)
    {
        return await _service.AddProducto(proveedor);
    }

    public async Task<Producto> DeleteProducto(int id)
    {
        return await _service.DeleteProducto(id);
    }

    public async Task<IQueryable<Producto>> GetAllProductos()
    {
        return await _service.GetAllProductos();
    }

    public async Task<Producto> GetProductorById(int id)
    {
        return await _service.GetProductorById(id);
    }

    public async Task<Producto> UpdateProducto(Producto proveedor)
    {
        return await _service.UpdateProducto(proveedor);
    }
}
