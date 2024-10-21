using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class SucursalRepository : IGenericRepository<Sucursal>
{
    private readonly LibreriaContext _context;
    public SucursalRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Sucursal> AddAsync(Sucursal entity)
    {
        try
        {
            await _context.Sucursals.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la sucursal: {ex.Message}");
        }
    }

    public async Task<Sucursal> DeleteAsync(int id)
    {
        try
        {
            var sucursalToDatabase = await _context.Sucursals.FindAsync(id);
            if (sucursalToDatabase == null)
            {
                throw new Exception("Sucursal no encontrada");
            }
            _context.Sucursals.Remove(sucursalToDatabase);
            await _context.SaveChangesAsync();
            return sucursalToDatabase;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la sucursal: {ex.Message}");
        }

    }

    public Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        return _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
    }

    public Task<IQueryable<Sucursal>> GetAllAsync()
    {
        try
        {
            IQueryable<Sucursal> sucursals = _context.Sucursals;
            return Task.FromResult(sucursals);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las sucursales: {ex.Message}");
        }
    }

    public async Task<Sucursal> GetByIdAsync(int id)
    {
        try
        {
            var sucursalToDatabase = await _context.Sucursals.FindAsync(id);
            if (sucursalToDatabase != null)
            {
                return sucursalToDatabase;
            }
            throw new Exception("Sucursal no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la sucursal: {ex.Message}");
        }
    }

    public async Task<Sucursal> UpdateAsync(Sucursal entity)
    {
        try
        {
            var sucursalToDatabase = await _context.Sucursals.FindAsync(entity.Id);
            if (sucursalToDatabase != null)
            {
                _context.Sucursals.Update(entity);
                await _context.SaveChangesAsync();
                return sucursalToDatabase;
            }
            throw new Exception("Sucursal no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar la sucursal: {ex.Message}");
        }
    }
}
