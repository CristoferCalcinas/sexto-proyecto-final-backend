using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IPedidoProveedorService
{
    Task<IQueryable<PedidoProveedor>> GetAllPedidoProveedor();
    Task<PedidoProveedor> AddPedidoProveedor(PedidoProveedor pedidoProveedor);
    Task<PedidoProveedor> DeletePedidoProveedor(int id);
    Task<PedidoProveedor> GetPedidoProveedorById(int id);
    Task<PedidoProveedor> UpdatePedidoProveedor(PedidoProveedor pedidoProveedor);
}
