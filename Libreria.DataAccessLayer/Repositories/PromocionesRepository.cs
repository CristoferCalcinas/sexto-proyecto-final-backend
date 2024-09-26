using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class PromocionesRepository : IGenericRepository<Promocione>
{
    private readonly LibreriaContext _context;
    public PromocionesRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Promocione> AddAsync(Promocione entity)
    {
        try
        {
            await _context.Promociones.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la promoción: {ex.Message}");
        }
    }

    public Task<Promocione> DeleteAsync(int id)
    {
        try
        {
            var promocionToDelete = _context.Promociones.Find(id);
            if (promocionToDelete == null)
            {
                throw new Exception("Promoción no encontrada");
            }
            _context.Promociones.Remove(promocionToDelete);
            _context.SaveChanges();
            return Task.FromResult(promocionToDelete);
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

    public Task<IQueryable<Promocione>> GetAllAsync()
    {
        try
        {
            IQueryable<Promocione> promociones = _context.Promociones;
            return Task.FromResult(promociones);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las promociones: {ex.Message}");
        }
    }

    public async Task<Promocione> GetByIdAsync(int id)
    {
        try
        {
            var promocionesToDatabase = await _context.Promociones.FindAsync(id);
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

    public async Task<Promocione> UpdateAsync(Promocione entity)
    {
        try
        {
            var promocionesToUpdate = await _context.Promociones.FindAsync(entity.Id);
            if (promocionesToUpdate != null)
            {
                _context.Entry(promocionesToUpdate).CurrentValues.SetValues(entity);
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
