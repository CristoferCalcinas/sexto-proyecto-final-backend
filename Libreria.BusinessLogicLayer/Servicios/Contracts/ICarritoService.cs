using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICarritoService
{
    Task<Carrito> AddCarritoCompra(Carrito carritoCompra);
    Task<Carrito> DeleteCarritoCompra(int id);
    Task<IQueryable<Carrito>> GetAllCarritoCompras();
    Task<Carrito> GetCarritoCompraById(int id);
    Task<Carrito> UpdateCarritoCompra(Carrito carritoCompra);
    Task<List<Carrito>> GetAllWithDetailsCarritoCompras(int id);
}
