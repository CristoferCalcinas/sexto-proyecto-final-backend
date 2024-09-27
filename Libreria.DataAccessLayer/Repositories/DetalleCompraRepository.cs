using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class DetalleCompraRepository : IGenericRepository<DetalleCompra>
{
    private readonly LibreriaContext _context;
    public DetalleCompraRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<DetalleCompra> AddAsync(DetalleCompra entity)
    {
        try
        {
            await _context.DetalleCompras.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el detalle de compra: {ex.Message}");
        }
    }

    public async Task<DetalleCompra> DeleteAsync(int id)
    {
        try
        {
            var detalleCompraToDelete = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompraToDelete != null)
            {
                _context.DetalleCompras.Remove(detalleCompraToDelete);
                await _context.SaveChangesAsync();
                return detalleCompraToDelete;
            }
            throw new Exception("Detalle de compra no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el detalle de compra: {ex.Message}");
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

    public Task<IQueryable<DetalleCompra>> GetAllAsync()
    {
        try
        {
            IQueryable<DetalleCompra> detalleCompras = _context.DetalleCompras;
            return Task.FromResult(detalleCompras);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los detalles de compra: {ex.Message}");
        }
    }

    public async Task<DetalleCompra> GetByIdAsync(int id)
    {
        try
        {
            var detalleCompraToDatabase = await _context.DetalleCompras.FindAsync(id);
            if (detalleCompraToDatabase != null)
            {
                return detalleCompraToDatabase;
            }
            throw new Exception("Detalle de compra no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el detalle de compra: {ex.Message}");
        }
    }

    public async Task<DetalleCompra> UpdateAsync(DetalleCompra entity)
    {
        try
        {
            var detalleCompraToDatabase = await _context.DetalleCompras.FindAsync(entity.Id);
            if(detalleCompraToDatabase != null)
            {
                _context.DetalleCompras.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Detalle de compra no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el detalle de compra: {ex.Message}");
        }
    }
}
