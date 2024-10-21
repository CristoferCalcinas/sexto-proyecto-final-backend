using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioService _envioService;
        public EnvioController(IEnvioService envioService)
        {
            _envioService = envioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnvios()
        {
            try
            {
                var envios = await _envioService.GetAllEnvios();
                return Ok(envios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
