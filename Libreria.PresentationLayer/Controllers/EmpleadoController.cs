using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _service;
        public EmpleadoController(IEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmpleados()
        {
            try
            {
                var empleados = await _service.GetAllEmpleados();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadoById(int id)
        {
            try
            {
                var empleado = await _service.GetEmpleadoById(id);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddEmpleado([FromBody] EmpleadoViewModel empleado)
        {
            try
            {
                Empleado newEmpleado = new Empleado
                {
                    Cargo = empleado.Cargo,
                    CorreoElectrónico = empleado.CorreoElectrónico,
                    NombreEmpleado = empleado.NombreEmpleado,
                    Teléfono = empleado.Teléfono,
                };

                var result = await _service.AddEmpleado(newEmpleado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] EmpleadoViewModel empleado)
        {
            try
            {
                Empleado newEmpleado = new Empleado
                {
                    Id = empleado.Id,
                    Cargo = empleado.Cargo,
                    CorreoElectrónico = empleado.CorreoElectrónico,
                    NombreEmpleado = empleado.NombreEmpleado,
                    Teléfono = empleado.Teléfono,
                };

                var result = await _service.UpdateEmpleado(newEmpleado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var empleado = await _service.DeleteEmpleado(id);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
