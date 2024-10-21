using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _service.GetAllClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            try
            {
                var cliente = await _service.GetClienteById(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteViewModel cliente)
        {
            try
            {
                Cliente newCliente = new Cliente
                {
                    CorreoElectronico = cliente.CorreoElectrónico,
                    FechaRegistro = cliente.FechaRegistro,
                    NombreCliente = cliente.NombreCliente,
                };

                var result = await _service.AddCliente(newCliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteViewModel cliente)
        {
            try
            {
                Cliente newCliente = new Cliente
                {
                    Id = cliente.Id,
                    CorreoElectronico = cliente.CorreoElectrónico,
                    FechaRegistro = cliente.FechaRegistro,
                    NombreCliente = cliente.NombreCliente,
                };

                var result = await _service.UpdateCliente(newCliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var result = await _service.DeleteCliente(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
