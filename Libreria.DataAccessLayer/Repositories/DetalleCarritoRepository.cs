using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class DetalleCarritoRepository : IGenericRepository<DetalleCarrito>
{
    private readonly LibreriaContext _context;
    public DetalleCarritoRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<DetalleCarrito> AddAsync(DetalleCarrito entity)
    {
        try
        {
            await _context.DetalleCarritos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;       
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el detalle de carrito: {ex.Message}");
        }
    }

    public async Task<DetalleCarrito> DeleteAsync(int id)
    {
        try
        {
            var detalleCarritoToDelete = await _context.DetalleCarritos.FindAsync(id);
            if (detalleCarritoToDelete != null)
            {
                _context.DetalleCarritos.Remove(detalleCarritoToDelete);
                await _context.SaveChangesAsync();
                return detalleCarritoToDelete;
            }
            throw new Exception("Detalle de carrito no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el detalle de carrito: {ex.Message}");
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

    public Task<IQueryable<DetalleCarrito>> GetAllAsync()
    {
        try
        {
            IQueryable<DetalleCarrito> detalles = _context.DetalleCarritos;
            return Task.FromResult(detalles);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los detalles de carrito: {ex.Message}");
        }
    }

    public async Task<DetalleCarrito> GetByIdAsync(int id)
    {
        try
        {
            var detalleToDatabase = await _context.DetalleCarritos.FindAsync(id);
            if(detalleToDatabase != null)
            {
                return detalleToDatabase;
            }
            throw new Exception("Detalle de carrito no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el detalle de carrito: {ex.Message}");
        }
    }

    public async Task<DetalleCarrito> UpdateAsync(DetalleCarrito entity)
    {
        try
        {
            var detalleToUpdate = await _context.DetalleCarritos.FindAsync(entity.Id);
            if(detalleToUpdate != null){
                _context.DetalleCarritos.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Detalle de carrito no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el detalle de carrito: {ex.Message}");
        }
    }
}
