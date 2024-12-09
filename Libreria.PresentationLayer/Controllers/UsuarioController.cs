using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            try
            {
                var usuarios = await _service.GetAllUsuario();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los usuarios", ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _service.GetUsuarioById(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el usuario", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario(Usuario usuario)
        {
            try
            {

                var usuarioCreado = await _service.AddUsuario(usuario);
                return Ok(usuarioCreado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el usuario", ex.Message);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario(Usuario usuario)
        {
            try
            {
                var usuarioActualizado = await _service.UpdateUsuario(usuario);
                return Ok(usuarioActualizado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el usuario", ex.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {

                var usuarioEliminado = await _service.DeleteUsuario(id);
                return Ok(usuarioEliminado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el usuario", ex.Message);
                throw;
            }
        }
    }
}
