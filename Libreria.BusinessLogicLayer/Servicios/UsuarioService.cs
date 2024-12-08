using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.DataAccessLayer.Migracion;
using Libreria.DataAccessLayer.Repositories.Contract;

namespace Libreria.BusinessLogicLayer.Servicios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<Usuario> AddUsuario(Usuario usuario)
    {
        return await _repository.AddAsync(usuario);
    }

    public async Task<Usuario> DeleteUsuario(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IQueryable<Usuario>> GetAllUsuario()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Usuario> GetUsuarioById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Usuario> UpdateUsuario(Usuario usuario)
    {
        return await _repository.UpdateAsync(usuario);
    }
}
