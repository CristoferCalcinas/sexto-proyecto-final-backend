using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios;

public class EmpleadoService : IEmpleadoService
{
    private readonly IGenericRepository<Empleado> _genericRepository;
    public EmpleadoService(IGenericRepository<Empleado> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Empleado> AddEmpleado(Empleado empleado)
    {
        return await _genericRepository.AddAsync(empleado);
    }

    public async Task<Empleado> DeleteEmpleado(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IQueryable<Empleado>> GetAllEmpleados()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Empleado> GetEmpleadoById(int id)
    {
        return await _genericRepository.GetByIdAsync(id);
    }

    public async Task<Empleado> UpdateEmpleado(Empleado empleado)
    {
        return await _genericRepository.UpdateAsync(empleado);
    }
}
