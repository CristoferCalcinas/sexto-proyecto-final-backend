using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CuponRepository : IGenericRepository<Cupon>
{
    private readonly LibreriaContext _context;
    public CuponRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Cupon> AddAsync(Cupon entity)
    {
        try
        {
            await _context.Cupons.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {            
            throw new Exception($"Error al agregar el cupón: {ex.Message}");
        }
    }

    public async Task<Cupon> DeleteAsync(int id)
    {
        try
        {
            var cuponToDelete = await _context.Cupons.FindAsync(id);
            if (cuponToDelete != null)
            {
                _context.Cupons.Remove(cuponToDelete);
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

    public Task<IQueryable<Cupon>> GetAllAsync()
    {
        try
        {
            IQueryable<Cupon> cupones = _context.Cupons;
            return Task.FromResult(cupones);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los cupones: {ex.Message}");
        }
    }

    public async Task<Cupon> GetByIdAsync(int id)
    {
        try
        {
            var cuponToDatabase = await _context.Cupons.FindAsync(id);
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

    public async Task<Cupon> UpdateAsync(Cupon entity)
    {
        try
        {
            var cuponToDatabase = await _context.Cupons.FindAsync(entity.Id);
            if(cuponToDatabase != null)
            {
                _context.Cupons.Update(entity);
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
