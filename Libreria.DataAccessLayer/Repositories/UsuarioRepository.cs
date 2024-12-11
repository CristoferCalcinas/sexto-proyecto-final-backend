using Libreria.Models;
using Libreria.DataAccessLayer.Repositories.Contract;
using Libreria.DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;

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
            IQueryable<Usuario> usuarios = _context.Usuarios.AsNoTracking().Include(r => r.Rol);
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
            var entity = await _context.Usuarios.Include(r => r.Rol).FirstOrDefaultAsync(u => u.Id == id);
            if (entity != null)
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

    public async Task<Usuario> LoginAsync(string correoElectronico, string password)
    {
        try
        {
            var user = await _context.Usuarios
                                            .Include(r => r.Rol)
                                            .FirstOrDefaultAsync(u => u.CorreoElectronico == correoElectronico && u.Contrasena == password);
            if (user != null)
            {
                return user;
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

    public async Task<Usuario> ChangeRoleToUserAsync(int usuarioId)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId)
            ?? throw new InvalidOperationException($"Usuario con ID {usuarioId} no encontrado");

        var rolUsuario = await _context.Rols
            .FirstOrDefaultAsync(r => r.NombreRol == "Cliente")
            ?? throw new InvalidOperationException("Rol de Usuario no encontrado");

        usuario.RolId = rolUsuario.Id;

        try
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Error al actualizar rol de usuario {usuarioId}", ex);
            throw;
        }
    }

    
    public async Task<Usuario> ChangeRoleToEmployeeAsync(int usuarioId)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId)
            ?? throw new InvalidOperationException($"Usuario con ID {usuarioId} no encontrado");

        var rolUsuario = await _context.Rols
            .FirstOrDefaultAsync(r => r.NombreRol == "Empleado")
            ?? throw new InvalidOperationException("Rol de Usuario no encontrado");

        usuario.RolId = rolUsuario.Id;

        try
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Error al actualizar rol de usuario {usuarioId}", ex);
            throw;
        }
    }

}
