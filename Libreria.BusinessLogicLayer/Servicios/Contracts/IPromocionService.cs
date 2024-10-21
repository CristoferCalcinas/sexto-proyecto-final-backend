using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IPromocionService
{
    Task<IQueryable<Promocion>> GetAllPromociones();
    Task<Promocion> AddPromocion(Promocion promocion);
    Task<Promocion> DeletePromocion(int id);
    Task<Promocion> GetPromocionById(int id);
    Task<Promocion> UpdatePromocion(Promocion promocion);
}
