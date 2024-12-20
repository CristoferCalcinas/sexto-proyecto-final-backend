using System.ComponentModel.DataAnnotations;
using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
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
        public async Task<IActionResult> AddUsuario([FromBody] UsuarioViewModel usuario)
        {
            try
            {
                // Validaciones adicionales
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                    return BadRequest(new { mensaje = "El nombre de usuario es requerido" });

                if (string.IsNullOrWhiteSpace(usuario.CorreoElectronico) || !IsValidEmail(usuario.CorreoElectronico))
                    return BadRequest(new { mensaje = "El correo electrónico es inválido" });

                if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                    return BadRequest(new { mensaje = "La contraseña es requerida" });

                if (string.IsNullOrWhiteSpace(usuario.Telefono))
                    usuario.Telefono = "N/A";

                // Mapear UsuarioViewModel a Usuario
                var nuevoUsuario = new Usuario
                {
                    Contrasena = usuario.Contrasena,
                    CorreoElectronico = usuario.CorreoElectronico,
                    Estado = true,
                    FechaRegistro = DateOnly.FromDateTime(DateTime.Now),
                    NombreUsuario = usuario.NombreUsuario,
                    // el rol id tiene que ser por defecto "cliente"
                    // para eso esta el id 2
                    // sin embargo si esto cambia se debe cambiar el id
                    // o deberiamos asegurarnos de traer el id del rol "cliente"
                    RolId = 2,
                    Telefono = usuario.Telefono,
                };

                // Llamar al servicio para agregar el usuario
                var usuarioCreado = await _service.AddUsuario(nuevoUsuario);
                return Ok(usuarioCreado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el usuario", ex.Message);
                return StatusCode(500, new { mensaje = "Error interno del servidor" });
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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

        [HttpPatch]
        public async Task<IActionResult> ChangeRoleToUser([FromBody] UserRoleChangeRequest request)
        {
            try
            {
                var usuario = await _service.ChangeRoleToUser(request.UserId);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar el rol del usuario", ex.Message);
                throw;
            }
        }

        [HttpPatch("employee")]
        public async Task<IActionResult> ChangeRoleToEmployee([FromBody] UserRoleChangeRequest request)
        {
            try
            {
                var usuario = await _service.ChangeRoleToEmployee(request.UserId);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar el rol del usuario", ex.Message);
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

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetUserInactive([FromBody] UserRoleChangeRequest request)
        {
            try
            {
                var usuario = await _service.SetUserInactive(request.UserId);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cambiar el estado del usuario", ex.Message);
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { mensaje = "Datos de inicio de sesión inválidos" });
            }

            try
            {
                var usuario = await _service.Login(loginRequest.CorreoElectronico, loginRequest.Password);

                if (usuario == null)
                {
                    return Unauthorized(new { mensaje = "Credenciales inválidas" });
                }

                return Ok(new
                {
                    mensaje = "Inicio de sesión exitoso",
                    usuario = usuario
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar sesión", ex.Message);
                return StatusCode(500, new
                {
                    mensaje = "Error interno del servidor",
                    detalles = "No se pudo completar el inicio de sesión"
                });
            }
        }
    }
}

public record UserRoleChangeRequest(int UserId);

public class LoginRequestDto
{
    [Required(ErrorMessage = "El correo electrónico es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
    public required string CorreoElectronico { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
    public required string Password { get; set; }
}