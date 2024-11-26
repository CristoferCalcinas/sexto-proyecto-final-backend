using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly LibreriaContext _context;
    public ClienteRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AddAsync(Cliente entity)
    {
        try
        {
            await _context.Clientes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el cliente: {ex.Message}");
        }
    }

    public async Task<Cliente> DeleteAsync(int id)
    {
        try
        {
            var clienteToDatabase = await _context.Clientes.FindAsync(id);
            if (clienteToDatabase != null)
            {
                _context.Clientes.Remove(clienteToDatabase);
                await _context.SaveChangesAsync();
                return clienteToDatabase;
            }
            throw new Exception("Cliente no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el cliente: {ex.Message}");
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

    public Task<IQueryable<Cliente>> GetAllAsync()
    {
        try
        {
            IQueryable<Cliente> clientes = _context.Clientes;
            return Task.FromResult(clientes);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los clientes: {ex.Message}");
        }
    }

    public async Task<Cliente> GetByCorreoAsync(string correo)
    {
        try
        {
            var clienteToDatabase = await _context.Clientes.FirstOrDefaultAsync(c => c.CorreoElectronico == correo);
            if (clienteToDatabase != null)
            {
                return clienteToDatabase;
            }
            throw new Exception("Cliente no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el cliente: {ex.Message}");
        }
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        try
        {
            var clienteToDatabase = await _context.Clientes.FindAsync(id);
            if (clienteToDatabase != null)
            {
                return clienteToDatabase;
            }
            throw new Exception("Cliente no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el cliente: {ex.Message}");
        }
    }

    public async Task<Cliente> UpdateAsync(Cliente entity)
    {
        try
        {
            var clienteToDatabase = await _context.Clientes.FindAsync(entity.Id);
            if (clienteToDatabase != null)
            {
                _context.Entry(clienteToDatabase).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return clienteToDatabase;
            }
            throw new Exception("Cliente no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el cliente: {ex.Message}");
        }
    }
}
