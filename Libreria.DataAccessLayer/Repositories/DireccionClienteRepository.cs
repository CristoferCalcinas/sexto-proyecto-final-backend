using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class DireccionClienteRepository : IGenericRepository<DireccionCliente>
{
    private readonly LibreriaContext _context;
    public DireccionClienteRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<DireccionCliente> AddAsync(DireccionCliente entity)
    {
        try
        {
            await _context.DireccionClientes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la dirección del cliente: {ex.Message}");
        }
    }

    public async Task<DireccionCliente> DeleteAsync(int id)
    {
        try
        {
            var direccionClienteToDelete = await _context.DireccionClientes.FindAsync(id);
            if (direccionClienteToDelete != null)
            {
                _context.DireccionClientes.Remove(direccionClienteToDelete);
                await _context.SaveChangesAsync();
                return direccionClienteToDelete;
            }
            throw new Exception("Dirección del cliente no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la dirección del cliente: {ex.Message}");
        }
    }

    public async Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        return await _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
    }

    public Task<IQueryable<DireccionCliente>> GetAllAsync()
    {
        try
        {
            IQueryable<DireccionCliente> direccionClientes = _context.DireccionClientes;
            return Task.FromResult(direccionClientes);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las direcciones de los clientes: {ex.Message}");
        }
    }

    public async Task<DireccionCliente> GetByIdAsync(int id)
    {
        try
        {
            var direccionCliente = await _context.DireccionClientes.FindAsync(id);
            if (direccionCliente != null)
            {
                return direccionCliente;
            }
            throw new Exception("Dirección del cliente no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la dirección del cliente: {ex.Message}");
        }
    }

    public async Task<DireccionCliente> UpdateAsync(DireccionCliente entity)
    {
        try
        {
            var direccionClienteToDatabase = await _context.DireccionClientes.FindAsync(entity.Id);
            if (direccionClienteToDatabase != null)
            {
                _context.DireccionClientes.Update(entity);
                await _context.SaveChangesAsync();
                return direccionClienteToDatabase;
            }
            throw new Exception("Dirección del cliente no encontrada");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar la dirección del cliente: {ex.Message}");
        }
    }
}
