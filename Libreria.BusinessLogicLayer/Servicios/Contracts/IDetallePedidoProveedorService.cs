using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IDetallePedidoProveedorService
{
    Task<DetallePedidoProveedor> AddDetallePedidoProveedor(DetallePedidoProveedor detallePedidoProveedor);
    Task<DetallePedidoProveedor> DeleteDetallePedidoProveedor(int id);
    Task<DetallePedidoProveedor> GetDetallePedidoProveedorById(int id);
    Task<DetallePedidoProveedor> UpdateDetallePedidoProveedor(DetallePedidoProveedor detallePedidoProveedor);
    Task<IQueryable<DetallePedidoProveedor>> GetAllDetallePedidoProveedores();
}
