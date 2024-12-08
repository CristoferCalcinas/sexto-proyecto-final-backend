using Libreria.DataAccessLayer.Migracion;
using Libreria.DataAccessLayer.Repositories.Contract;

namespace Libreria.DataAccessLayer.Repositories;

public class RolRepository : IRolRepository
{
    private readonly LibreriaContext _context;
    public RolRepository(LibreriaContext context)
    {
        _context = context;
    }
    public async Task<Rol> AddAsync(Rol entity)
    {
        try
        {
            await _context.Rols.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Rol> DeleteAsync(int id)
    {
        try
        {
            var entityToDatabase = await _context.Rols.FindAsync(id);
            if (entityToDatabase != null)
            {
                _context.Rols.Remove(entityToDatabase);
                await _context.SaveChangesAsync();
                return entityToDatabase;
            }
            throw new Exception("Rol no encontrado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public Task<List<TResult>> ExecuteQueryAsync<TResult>(string query) where TResult : class
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Rol>> GetAllAsync()
    {
        try
        {
            IQueryable<Rol> entities = _context.Rols;
            return Task.FromResult(entities);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Rol> GetByIdAsync(int id)
    {
        try
        {
            var entityToDatabase = await _context.Rols.FindAsync(id);
            if(entityToDatabase != null)
            {
                return entityToDatabase;
            }
            throw new Exception("Rol no encontrado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }       
    }

    public async Task<Rol> UpdateAsync(Rol entity)
    {
        try
        {
            var entityToDatabase = await _context.Rols.FindAsync(entity.Id);
            if(entityToDatabase != null)
            {
                 _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Rol no encontrado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
