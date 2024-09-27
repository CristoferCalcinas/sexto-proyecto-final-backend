using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICarritoCompraService
{
    Task<CarritoCompra> AddCarritoCompra(CarritoCompra carritoCompra);
    Task<CarritoCompra> DeleteCarritoCompra(int id);
    Task<IQueryable<CarritoCompra>> GetAllCarritoCompras();
    Task<CarritoCompra> GetCarritoCompraById(int id);
    Task<CarritoCompra> UpdateCarritoCompra(CarritoCompra carritoCompra);
}
