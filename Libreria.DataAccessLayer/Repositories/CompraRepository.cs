using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CompraRepository : IComprasRepository
{
    private readonly LibreriaContext _context;
    public CompraRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Compra> AddAsync(Compra entity)
    {
        try
        {
            await _context.Compras.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar la compra: {ex.Message}");
        }
    }

    public async Task<object> AddDetalleCompraAsync(DetalleCompra detalleCompra)
    {
        try
        {
            await _context.DetalleCompras.AddAsync(detalleCompra);
            await _context.SaveChangesAsync();
            return detalleCompra;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public Task<Compra> DeleteAsync(int id)
    {
        try
        {
            var cuponToDelete = _context.Compras.Find(id);
            if (cuponToDelete != null)
            {
                _context.Compras.Remove(cuponToDelete);
                _context.SaveChanges();
                return Task.FromResult(cuponToDelete);
            }
            throw new Exception("Cupón no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el cupón: {ex.Message}");
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

    public Task<IQueryable<Compra>> GetAllAsync()
    {
        try
        {
            IQueryable<Compra> cupones = _context.Compras;
            return Task.FromResult(cupones);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los cupones: {ex.Message}");
        }
    }

    public async Task<Compra> GetByIdAsync(int id)
    {
        try
        {
            var cuponToDatabase = await _context.Compras.FindAsync(id);
            if (cuponToDatabase != null)
            {
                return cuponToDatabase;
            }
            throw new Exception("Cupón no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el cupón: {ex.Message}");
        }
    }

    public async Task<Compra> UpdateAsync(Compra entity)
    {
        try
        {
            var cuponToDatabase = await _context.Compras.FindAsync(entity.Id);
            if (cuponToDatabase != null)
            {
                _context.Compras.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Cupón no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el cupón: {ex.Message}");
        }
    }
}
