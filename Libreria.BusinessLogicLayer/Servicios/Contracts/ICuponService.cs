using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface ICuponService
{
    Task<Cupon> AddCupon(Cupon cupon);
    Task<Cupon> DeleteCupon(int id);
    Task<IQueryable<Cupon>> GetAllCupones();
    Task<Cupon> GetCuponById(int id);
    Task<Cupon> UpdateCupon(Cupon cupon);
}
