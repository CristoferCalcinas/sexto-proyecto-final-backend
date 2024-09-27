using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class DetallePedidoProveedorRepository : IGenericRepository<DetallePedidoProveedor>
{
    private readonly LibreriaContext _context;
    public DetallePedidoProveedorRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<DetallePedidoProveedor> AddAsync(DetallePedidoProveedor entity)
    {
        try
        {
            await _context.DetallePedidoProveedors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el detalle del pedido: {ex.Message}");
        }
    }

    public async Task<DetallePedidoProveedor> DeleteAsync(int id)
    {
        try
        {
            var detallePedidoToDelete = await _context.DetallePedidoProveedors.FindAsync(id);
            if (detallePedidoToDelete != null)
            {
                _context.DetallePedidoProveedors.Remove(detallePedidoToDelete);
                await _context.SaveChangesAsync();
                return detallePedidoToDelete;
            }
            throw new Exception("Detalle del pedido no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el detalle del pedido: {ex.Message}");
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

    public Task<IQueryable<DetallePedidoProveedor>> GetAllAsync()
    {
        try
        {
            IQueryable<DetallePedidoProveedor> detallePedidoProveedors = _context.DetallePedidoProveedors;
            return Task.FromResult(detallePedidoProveedors);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los detalles del pedido: {ex.Message}");
        }
    }

    public async Task<DetallePedidoProveedor> GetByIdAsync(int id)
    {
        try
        {
            var detallePedidoProveedorToDatabase = await _context.DetallePedidoProveedors.FindAsync(id);
            if (detallePedidoProveedorToDatabase != null)
            {
                return detallePedidoProveedorToDatabase;
            }
            throw new Exception("Detalle del pedido no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el detalle del pedido: {ex.Message}");
        }
    }

    public async Task<DetallePedidoProveedor> UpdateAsync(DetallePedidoProveedor entity)
    {
        try
        {
            var detallePedidoToUpdate = await _context.DetallePedidoProveedors.FindAsync(entity.Id);
            if (detallePedidoToUpdate != null)
            {
                _context.DetallePedidoProveedors.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Detalle del pedido no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el detalle del pedido: {ex.Message}");
        }
    }
}
