using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CarritoCompraRepository : IGenericRepository<CarritoCompra>
{
    private readonly LibreriaContext _context;
    public CarritoCompraRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<CarritoCompra> AddAsync(CarritoCompra entity)
    {
        try
        {
            await _context.CarritoCompras.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el carrito de compra: {ex.Message}");
        }
    }

    public async Task<CarritoCompra> DeleteAsync(int id)
    {
        try
        {
            var carritoToDelete = await _context.CarritoCompras.FindAsync(id);
            if (carritoToDelete != null)
            {
                _context.CarritoCompras.Remove(carritoToDelete);
                await _context.SaveChangesAsync();
                return carritoToDelete;
            }
            throw new Exception("Carrito de compra no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar el carrito de compra: {ex.Message}");
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

    public Task<IQueryable<CarritoCompra>> GetAllAsync()
    {
        try
        {
            IQueryable<CarritoCompra> carritos = _context.CarritoCompras;
            return Task.FromResult(carritos);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los carritos de compra: {ex.Message}");
        }
    }

    public async Task<CarritoCompra> GetByIdAsync(int id)
    {
        try
        {
            var carritoCompraToDatabase = await _context.CarritoCompras.FindAsync(id);
            if (carritoCompraToDatabase != null)
            {
                return carritoCompraToDatabase;
            }
            throw new Exception("Carrito de compra no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el carrito de compra: {ex.Message}");
        }
    }

    public async Task<CarritoCompra> UpdateAsync(CarritoCompra entity)
    {
        try
        {
            var carritoCompraToDatabase = await _context.CarritoCompras.FindAsync(entity.Id);
            if (carritoCompraToDatabase != null)
            {
                _context.CarritoCompras.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Carrito de compra no encontrado");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al actualizar el carrito de compra: {ex.Message}");
        }
    }
}
