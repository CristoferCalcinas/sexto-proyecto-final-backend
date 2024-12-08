using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Migracion;
using Libreria.DataAccessLayer.Repositories.Contract;

namespace Libreria.BusinessLogicLayer.Servicios;

public class RolService : IRolService
{
    private readonly IRolRepository _service;
    public RolService(IRolRepository service)
    {
        _service = service;
    }
    public async Task<Rol> AddRol(Rol rol)
    {
        return await _service.AddAsync(rol);
    }

    public async Task<Rol> DeleteRol(int id)
    {
        return await _service.DeleteAsync(id);
    }

    public async Task<IQueryable<Rol>> GetAllRols()
    {
        return await _service.GetAllAsync();
    }

    public async Task<Rol> GetRolById(int id)
    {
        return await _service.GetByIdAsync(id);
    }

    public async Task<Rol> UpdateRol(Rol rol)
    {
        return await _service.UpdateAsync(rol);
    }
}
