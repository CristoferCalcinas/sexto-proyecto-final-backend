using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class EmpleadoRepository : IGenericRepository<Empleado>
{
    private readonly LibreriaContext _context;
    public EmpleadoRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Empleado> AddAsync(Empleado entity)
    {
        try
        {
            await _context.Empleados.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el empleado: {ex.Message}");
        }
    }

    public async Task<Empleado> DeleteAsync(int id)
    {
        try
        {
            var empleadoToDelete = await _context.Empleados.FindAsync(id);
            if (empleadoToDelete != null)
            {
                _context.Empleados.Remove(empleadoToDelete);
                await _context.SaveChangesAsync();
                return empleadoToDelete;
            }
            throw new Exception("Empleado no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el empleado: {ex.Message}");
        }
    }

    public async Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        try
        {
            return await _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al ejecutar la consulta: {ex.Message}");
        }
    }

    public Task<IQueryable<Empleado>> GetAllAsync()
    {
        try
        {
            IQueryable<Empleado> empleados = _context.Empleados;
            return Task.FromResult(empleados);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los empleados: {ex.Message}");
        }
    }

    public async Task<Empleado> GetByIdAsync(int id)
    {
        try
        {
            var empleadoToDatabase = await _context.Empleados.FindAsync(id);
            if (empleadoToDatabase != null)
            {
                return empleadoToDatabase;
            }
            throw new Exception("Empleado no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el empleado: {ex.Message}");
        }
    }

    public async Task<Empleado> UpdateAsync(Empleado entity)
    {
        try
        {
            var empleadoToUpdate = await _context.Empleados.FindAsync(entity.Id);
            if (empleadoToUpdate != null)
            {
                _context.Empleados.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Empleado no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el empleado: {ex.Message}");
        }
    }
}
