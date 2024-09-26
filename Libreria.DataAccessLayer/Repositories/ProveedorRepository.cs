using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class ProveedorRepository : IGenericRepository<Proveedor>
{
    private readonly LibreriaContext _context;
    public ProveedorRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Proveedor> AddAsync(Proveedor entity)
    {
        try
        {
            await _context.Proveedors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el proveedor: {ex.Message}");
        }
    }

    public async Task<Proveedor> DeleteAsync(int id)
    {
        try
        {
            var proveedorToDelete = await _context.Proveedors.FindAsync(id);
            if (proveedorToDelete == null)
            {
                throw new Exception("Proveedor no encontrado");
            }
            _context.Proveedors.Remove(proveedorToDelete);
            await _context.SaveChangesAsync();
            return proveedorToDelete;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el proveedor: {ex.Message}");
        }
    }

    public async Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        return await _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
    }

    public Task<IQueryable<Proveedor>> GetAllAsync()
    {
        try
        {
            IQueryable<Proveedor> proveedors = _context.Proveedors;
            return Task.FromResult(proveedors);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los proveedores: {ex.Message}");
        }
    }

    public async Task<Proveedor> GetByIdAsync(int id)
    {
        try
        {
            var proveedorToDatabase = await _context.Proveedors.FindAsync(id);
            if (proveedorToDatabase != null)
            {
                return proveedorToDatabase;
            }
            throw new Exception("Proveedor no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el proveedor: {ex.Message}");
        }
    }

    public async Task<Proveedor> UpdateAsync(Proveedor entity)
    {
        try
        {

            var proveedorToUpdate = await _context.Proveedors.FindAsync(entity.Id);
            if (proveedorToUpdate != null)
            {
                _context.Proveedors.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Proveedor no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el proveedor: {ex.Message}");
        }
    }
}
