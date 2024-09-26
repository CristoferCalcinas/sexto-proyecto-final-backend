using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {
        private readonly IPromocionesService _service;
        public PromocionesController(IPromocionesService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPromociones()
        {
            var promociones = await _service.GetAllPromociones();
            return Ok(promociones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromocionById(int id)
        {
            var promocion = await _service.GetPromocionById(id);
            return Ok(promocion);
        }

        [HttpPost]
        public async Task<IActionResult> AddPromocion([FromBody] PromocionesViewModel promocion)
        {
            Promocione promocionToAdd = new Promocione
            {
                Descuento = promocion.Descuento,
                FechaFin = promocion.FechaFin,
                FechaInicio = promocion.FechaInicio,
                NombrePromocion = promocion.NombrePromocion,
            };
            var result = await _service.AddPromocion(promocionToAdd);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePromocion([FromBody] PromocionesViewModel promocion)
        {
            var promocionToDatabase = await _service.GetPromocionById(promocion.Id);
            if ( promocionToDatabase == null)
            {
                return NotFound();
            }
            promocionToDatabase.Descuento = promocion.Descuento;
            promocionToDatabase.FechaFin = promocion.FechaFin;
            promocionToDatabase.FechaInicio = promocion.FechaInicio;
            promocionToDatabase.NombrePromocion = promocion.NombrePromocion;
            var result = await _service.UpdatePromocion(promocionToDatabase);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocion(int id)
        {
            var promocion = await _service.GetPromocionById(id);
            if (promocion == null)
            {
                return NotFound();
            }
            var result = await _service.DeletePromocion(id);
            return Ok(result);
        }
    }
}
