using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CuponesRepository : IGenericRepository<Cupone>
{
    private readonly LibreriaContext _context;
    public CuponesRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Cupone> AddAsync(Cupone entity)
    {
        try
        {
            await _context.Cupones.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {            
            throw new Exception($"Error al agregar el cupón: {ex.Message}");
        }
    }

    public async Task<Cupone> DeleteAsync(int id)
    {
        try
        {
            var cuponToDelete = await _context.Cupones.FindAsync(id);
            if (cuponToDelete != null)
            {
                _context.Cupones.Remove(cuponToDelete);
                await _context.SaveChangesAsync();
                return cuponToDelete;
            }
            throw new Exception("Cupón no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el cupón: {ex.Message}");
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

    public Task<IQueryable<Cupone>> GetAllAsync()
    {
        try
        {
            IQueryable<Cupone> cupones = _context.Cupones;
            return Task.FromResult(cupones);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los cupones: {ex.Message}");
        }
    }

    public async Task<Cupone> GetByIdAsync(int id)
    {
        try
        {
            var cuponToDatabase = await _context.Cupones.FindAsync(id);
            if(cuponToDatabase != null)
            {
                return cuponToDatabase;
            }
            throw new Exception("Cupón no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el cupón: {ex.Message}");
        }
    }

    public async Task<Cupone> UpdateAsync(Cupone entity)
    {
        try
        {
            var cuponToDatabase = await _context.Cupones.FindAsync(entity.Id);
            if(cuponToDatabase != null)
            {
                _context.Cupones.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Cupón no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el cupón: {ex.Message}");
        }
    }
}
