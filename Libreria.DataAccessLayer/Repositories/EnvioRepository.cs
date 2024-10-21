using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class EnvioRepository : IGenericRepository<Envio>
{
    private readonly LibreriaContext _context;
    public EnvioRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Envio> AddAsync(Envio entity)
    {
        try
        {
            await _context.Envios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el envio: {ex.Message}");
        }
    }

    public async Task<Envio> DeleteAsync(int id)
    {
        try
        {
            var envioToDatabase = await _context.Envios.FindAsync(id);
            if (envioToDatabase != null)
            {
                _context.Envios.Remove(envioToDatabase);
                await _context.SaveChangesAsync();
                return envioToDatabase;
            }
            throw new Exception("Envio no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el envio: {ex.Message}");
        }
    }

    public async Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        return await _context.Set<TResult>().FromSqlRaw(query).ToListAsync();
    }

    public Task<IQueryable<Envio>> GetAllAsync()
    {
        try
        {
            IQueryable<Envio> envios = _context.Envios;
            return Task.FromResult(envios);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los envios: {ex.Message}");
        }
    }

    public async Task<Envio> GetByIdAsync(int id)
    {
        try
        {
            var envioToDatabase = await _context.Envios.FindAsync(id);
            if (envioToDatabase != null)
            {
                return envioToDatabase;
            }
            throw new Exception("Envio no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el envio: {ex.Message}");
        }
    }

    public async Task<Envio> UpdateAsync(Envio entity)
    {
        try
        {
            var envioToUpdate = await _context.Envios.FindAsync(entity.Id);
            if (envioToUpdate != null)
            {
                _context.Entry(envioToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return envioToUpdate;
            }
            throw new Exception("Envio no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el envio: {ex.Message}");
        }
    }
}
