using Libreria.DataAccessLayer.DataContext;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IPromocionesService
{
    Task<IQueryable<Promocione>> GetAllPromociones();
    Task<Promocione> GetPromocionById(int id);
    Task<Promocione> AddPromocion(Promocione promocion);
    Task<Promocione> DeletePromocion(int id);
    Task<Promocione> UpdatePromocion(Promocione promocion);
}
