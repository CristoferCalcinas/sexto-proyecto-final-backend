using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class InventarioRepository : IGenericRepository<Inventario>
{
    private readonly LibreriaContext _context;
    public InventarioRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Inventario> AddAsync(Inventario entity)
    {
        try
        {
            await _context.Inventarios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el inventario: {ex.Message}");
        }
    }

    public Task<Inventario> DeleteAsync(int id)
    {
        try
        {
            var inventarioToDelete = _context.Inventarios.Find(id);
            if (inventarioToDelete != null)
            {
                _context.Inventarios.Remove(inventarioToDelete);
                _context.SaveChanges();
                return Task.FromResult(inventarioToDelete);
            }
            throw new Exception("Inventario no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el inventario: {ex.Message}");
        }
    }

    public Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        try
        {
            return _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Error al ejecutar la consulta: {ex.Message}");
        }
    }

    public Task<IQueryable<Inventario>> GetAllAsync()
    {
        try
        {
            IQueryable<Inventario> inventarios = _context.Inventarios;
            return Task.FromResult(inventarios);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los inventarios: {ex.Message}");
        }
    }

    public async Task<Inventario> GetByIdAsync(int id)
    {
        try
        {
            var inventarioToDatabase = await _context.Inventarios.FindAsync(id);
            if (inventarioToDatabase != null)
            {
                return inventarioToDatabase;
            }
            throw new Exception("Inventario no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el inventario: {ex.Message}");
        }
    }

    public async Task<Inventario> UpdateAsync(Inventario entity)
    {
        try
        {
            var inventarioToDatabase = await _context.Inventarios.FindAsync(entity.Id);
            if (inventarioToDatabase != null)
            {
                _context.Inventarios.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Inventario no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el inventario: {ex.Message}");
        }
    }
}
