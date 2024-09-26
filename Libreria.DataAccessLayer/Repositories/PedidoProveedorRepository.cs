using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class PredidoProveedorRepository : IGenericRepository<PedidoProveedor>
{
    private readonly LibreriaContext _context;
    public PredidoProveedorRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<PedidoProveedor> AddAsync(PedidoProveedor entity)
    {
        try
        {
            await _context.PedidoProveedors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el pedido: {ex.Message}");
        }
    }

    public Task<PedidoProveedor> DeleteAsync(int id)
    {
        try
        {
            var pedidoToDelete = _context.PedidoProveedors.Find(id);
            if (pedidoToDelete != null)
            {
                _context.PedidoProveedors.Remove(pedidoToDelete);
                _context.SaveChanges();
                return Task.FromResult(pedidoToDelete);
            }
            throw new Exception("Pedido no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el pedido: {ex.Message}");
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

    public Task<IQueryable<PedidoProveedor>> GetAllAsync()
    {
        try
        {
            IQueryable<PedidoProveedor> pedidos = _context.PedidoProveedors;
            return Task.FromResult(pedidos);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los pedidos: {ex.Message}");
        }
    }

    public async Task<PedidoProveedor> GetByIdAsync(int id)
    {
        try
        {
            var pedidoProveedorToDatabase = await _context.PedidoProveedors.FindAsync(id);
            if (pedidoProveedorToDatabase != null)
            {
                return pedidoProveedorToDatabase;
            }
            throw new Exception("Pedido no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el pedido: {ex.Message}");
        }
    }

    public async Task<PedidoProveedor> UpdateAsync(PedidoProveedor entity)
    {
        try
        {
            var pedidoProveedorToDatabase = await _context.PedidoProveedors.FindAsync(entity.Id);
            if (pedidoProveedorToDatabase != null)
            {
                _context.PedidoProveedors.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Pedido no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el pedido: {ex.Message}");
        }
    }
}
