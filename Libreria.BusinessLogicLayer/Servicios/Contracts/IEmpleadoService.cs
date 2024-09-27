using Libreria.Models;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IEmpleadoService
{
    Task<Empleado> AddEmpleado(Empleado empleado);
    Task<Empleado> DeleteEmpleado(int id);
    Task<Empleado> GetEmpleadoById(int id);
    Task<Empleado> UpdateEmpleado(Empleado empleado);
    Task<IQueryable<Empleado>> GetAllEmpleados();
}
