using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IComprasService
{
    Task<Compra> AddCompra(Compra compra);
    Task<Compra> DeleteCompra(int id);
    Task<IQueryable<Compra>> GetAllCompras();
    Task<Compra> GetCompraById(int id);
    Task<Compra> UpdateCompra(Compra compra);
}
