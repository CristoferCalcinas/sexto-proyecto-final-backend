using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IPromocionesService
{
    Task<IQueryable<Promocione>> GetAllPromociones();
    Task<Promocione> AddPromocion(Promocione promocion);
    Task<Promocione> DeletePromocion(int id);
    Task<Promocione> GetPromocionById(int id);
    Task<Promocione> UpdatePromocion(Promocione promocion);
}
