using Libreria.DataAccessLayer.DataContext;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.DataAccessLayer.Repositories;

public class CarritoRepository : ICarritoRepository
{
    private readonly LibreriaContext _context;
    public CarritoRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Carrito> AddAsync(Carrito entity)
    {
        try
        {
            await _context.Carritos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al agregar el carrito de compra: {ex.Message}");
        }
    }

    public async Task<Carrito> DeleteAsync(int id)
    {
        try
        {
            var carritoToDelete = await _context.Carritos.FindAsync(id);
            if (carritoToDelete != null)
            {
                _context.Carritos.Remove(carritoToDelete);
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

    public Task<IQueryable<Carrito>> GetAllAsync()
    {
        try
        {
            IQueryable<Carrito> carritos = _context.Carritos;
            return Task.FromResult(carritos);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los carritos de compra: {ex.Message}");
        }
    }

    public async Task<Carrito> GetByIdAsync(int id)
    {
        try
        {
            var carritoCompraToDatabase = await _context.Carritos.FindAsync(id);
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

    public async Task<Carrito> UpdateAsync(Carrito entity)
    {
        try
        {
            var carritoCompraToDatabase = await _context.Carritos.FindAsync(entity.Id);
            if (carritoCompraToDatabase != null)
            {
                _context.Carritos.Update(entity);
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
    public async Task<List<Carrito>> GetAllWithDetailsAsync(int id)
    {
        try
        {
            var carritos = await _context.Carritos
                                          .Include(c => c.DetalleCarritos)
                                          .ThenInclude(dc => dc.Producto)
                                          //   .ThenInclude(p => p.Categoria)
                                          .Where(c => c.Id == id)
                                        //   .Take(5)
                                          .ToListAsync();
            return carritos;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los carritos de compra con detalles: {ex.Message}");
        }
    }
}
