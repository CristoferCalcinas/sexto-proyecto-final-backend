using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponesController : ControllerBase
    {
        private readonly ICuponesService _service;
        public CuponesController(ICuponesService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCupones()
        {
            try
            {
                var result = await _service.GetAllCupones();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuponById(int id)
        {
            try
            {
                var result = await _service.GetCuponById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCupon([FromBody] CuponesViewModel cupon)
        {
            try
            {
                Cupone newCupon = new Cupone
                {
                    CodigoCupon = cupon.CodigoCupon,
                    Descripción = cupon.Descripción,
                    Descuento = cupon.Descuento,
                    Estado = cupon.Estado,
                    FechaExpiracion = cupon.FechaExpiracion,
                };

                var result = await _service.AddCupon(newCupon);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCupon([FromBody] CuponesViewModel cupon)
        {
            try
            {
                Cupone newCupon = new Cupone
                {
                    Id = cupon.Id,
                    CodigoCupon = cupon.CodigoCupon,
                    Descripción = cupon.Descripción,
                    Descuento = cupon.Descuento,
                    Estado = cupon.Estado,
                    FechaExpiracion = cupon.FechaExpiracion,
                };

                var result = await _service.UpdateCupon(newCupon);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupon(int id)
        {
            try
            {
                var result = await _service.DeleteCupon(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
