using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class PromocionesRepository : IGenericRepository<Promocion>
{
    private readonly LibreriaContext _context;
    public PromocionesRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Promocion> AddAsync(Promocion entity)
    {
        try
        {
            await _context.Promocions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la promoción: {ex.Message}");
        }
    }

    public async Task<Promocion> DeleteAsync(int id)
    {
        try
        {
            var promocionToDelete = await _context.Promocions.FindAsync(id);
            if (promocionToDelete != null)
            {
                _context.Promocions.Remove(promocionToDelete);
                await _context.SaveChangesAsync();
                return promocionToDelete;
            }
            throw new Exception("Promoción no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la promoción: {ex.Message}");
        }
    }

    public async Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        return await _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
    }

    public Task<IQueryable<Promocion>> GetAllAsync()
    {
        try
        {
            IQueryable<Promocion> promociones = _context.Promocions;
            return Task.FromResult(promociones);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las promociones: {ex.Message}");
        }
    }

    public async Task<Promocion> GetByIdAsync(int id)
    {
        try
        {
            var promocionesToDatabase = await _context.Promocions.FindAsync(id);
            if (promocionesToDatabase != null)
            {
                return promocionesToDatabase;
            }
            throw new Exception("Promoción no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la promoción: {ex.Message}");
        }
    }

    public async Task<Promocion> UpdateAsync(Promocion entity)
    {
        try
        {
            var promocionesToUpdate = await _context.Promocions.FindAsync(entity.Id);
            if (promocionesToUpdate != null)
            {
                _context.Promocions.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Promoción no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar la promoción: {ex.Message}");
        }
    }
}
