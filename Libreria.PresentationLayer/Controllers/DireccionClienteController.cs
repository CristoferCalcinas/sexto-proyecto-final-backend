using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionClienteController : ControllerBase
    {
        private readonly IDireccionClienteService _service;
        public DireccionClienteController(IDireccionClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDireccionesClientes()
        {
            try
            {
                var direccionesClientes = await _service.GetAllDireccionCliente();
                return Ok(direccionesClientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
