using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IProductosService
{
    Task<IQueryable<Producto>> GetAllProductos();
    Task<Producto> AddProducto(Producto producto);
    Task<Producto> DeleteProducto(int id);
    Task<Producto> GetProductorById(int id);
    Task<Producto> UpdateProducto(Producto producto);
}
