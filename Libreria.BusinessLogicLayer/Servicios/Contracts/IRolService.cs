using Libreria.DataAccessLayer.Migracion;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IRolService
{
    Task<Rol> AddRol(Rol rol);
    Task<Rol> DeleteRol(int id);
    Task<Rol> GetRolById(int id);
    Task<Rol> UpdateRol(Rol rol);
    Task<IQueryable<Rol>> GetAllRols();
}
