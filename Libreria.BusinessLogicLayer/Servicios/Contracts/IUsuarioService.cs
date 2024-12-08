using Libreria.DataAccessLayer.Migracion;

namespace Libreria.BusinessLogicLayer.Servicios.Contracts;

public interface IUsuarioService
{
    Task<Usuario> AddUsuario(Usuario usuario);
    Task<Usuario> DeleteUsuario(int id);
    Task<IQueryable<Usuario>> GetAllUsuario();
    Task<Usuario> GetUsuarioById(int id);
    Task<Usuario> UpdateUsuario(Usuario usuario);
}