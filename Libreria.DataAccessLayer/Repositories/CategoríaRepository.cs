using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CategoríaRepository : IGenericRepository<Categoría>
{
    private readonly LibreriaContext _context;
    public CategoríaRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Categoría> AddAsync(Categoría entity)
    {
        try
        {
            await _context.Categorías.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la categoría: {ex.Message}");
        }
    }

    public Task<Categoría> DeleteAsync(int id)
    {
        try
        {
            var categoríaToDelete = _context.Categorías.Find(id);
            if (categoríaToDelete != null)
            {
                _context.Categorías.Remove(categoríaToDelete);
                _context.SaveChanges();
                return Task.FromResult(categoríaToDelete);
            }
            throw new Exception("Categoría no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la categoría: {ex.Message}");
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

    public Task<IQueryable<Categoría>> GetAllAsync()
    {
        try
        {
            IQueryable<Categoría> categorías = _context.Categorías;
            return Task.FromResult(categorías);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las categorías: {ex.Message}");
        }
    }

    public async Task<Categoría> GetByIdAsync(int id)
    {
        try
        {
            var categoriaToDatabase = await _context.Categorías.FindAsync(id);
            if (categoriaToDatabase != null)
            {
                return categoriaToDatabase;
            }
            throw new Exception("Categoría no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la categoría: {ex.Message}");
        }
    }

    public async Task<Categoría> UpdateAsync(Categoría entity)
    {
        try
        {
            var categoriaToDatabase = await _context.Categorías.FindAsync(entity.Id);
            if (categoriaToDatabase != null)
            {
                _context.Categorías.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Categoría no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar la categoría: {ex.Message}");
        }
    }
}
