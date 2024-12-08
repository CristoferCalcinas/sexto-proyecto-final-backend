using Libreria.DataAccessLayer.Migracion;
using Libreria.DataAccessLayer.Repositories.Contract;

namespace Libreria.DataAccessLayer.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly LibreriaContext _context;
    public UsuarioRepository(LibreriaContext context)
    {
        _context = context;
    }

    public async Task<Usuario> AddAsync(Usuario entity)
    {
        try
        {
            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Usuario> DeleteAsync(int id)
    {
        try
        {
            var entityToDatabase = await _context.Usuarios.FindAsync(id);
            if (entityToDatabase != null)
            {
                _context.Usuarios.Remove(entityToDatabase);
                await _context.SaveChangesAsync();
                return entityToDatabase;
            }
            throw new Exception("Usuario no encontrado");
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

    public Task<IQueryable<Usuario>> GetAllAsync()
    {
        try
        {
            IQueryable<Usuario> usuarios = _context.Usuarios;
            return Task.FromResult(usuarios);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        try
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if ( entity != null)
            {
                return entity;
            }
            throw new Exception("Usuario no encontrado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<Usuario> UpdateAsync(Usuario entity)
    {
        try
        {
            var entityToDatabase = await _context.Usuarios.FindAsync(entity.Id);
            if (entityToDatabase != null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            throw new Exception("Usuario no encontrado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}