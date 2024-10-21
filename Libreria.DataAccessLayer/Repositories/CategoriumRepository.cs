using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CategoriumRepository : IGenericRepository<Categorium>
{
    private readonly LibreriaContext _context;
    public CategoriumRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Categorium> AddAsync(Categorium entity)
    {
        try
        {
            await _context.Categoria.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la categoría: {ex.Message}");
        }
    }

    public async Task<Categorium> DeleteAsync(int id)
    {
        try
        {
            var categoríaToDelete = await _context.Categoria.FindAsync(id);
            if (categoríaToDelete != null)
            {
                _context.Categoria.Remove(categoríaToDelete);
                await _context.SaveChangesAsync();
                return categoríaToDelete;
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

    public Task<IQueryable<Categorium>> GetAllAsync()
    {
        try
        {
            IQueryable<Categorium> categorías = _context.Categoria;
            return Task.FromResult(categorías);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las categorías: {ex.Message}");
        }
    }

    public async Task<Categorium> GetByIdAsync(int id)
    {
        try
        {
            var categoriaToDatabase = await _context.Categoria.FindAsync(id);
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

    public async Task<Categorium> UpdateAsync(Categorium entity)
    {
        try
        {
            var categoriaToDatabase = await _context.Categoria.FindAsync(entity.Id);
            if (categoriaToDatabase != null)
            {
                _context.Categoria.Update(entity);
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
