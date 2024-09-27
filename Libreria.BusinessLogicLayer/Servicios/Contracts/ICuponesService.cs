using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICuponesService
{
    Task<Cupone> AddCupon(Cupone cupon);
    Task<Cupone> DeleteCupon(int id);
    Task<IQueryable<Cupone>> GetAllCupones();
    Task<Cupone> GetCuponById(int id);
    Task<Cupone> UpdateCupon(Cupone cupon);
}
