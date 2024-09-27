using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCarritoController : ControllerBase
    {
        private readonly IDetalleCarritoService _service;
        public DetalleCarritoController(IDetalleCarritoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDetalleCarritos()
        {
            try
            {
                var result = await _service.GetAllDetalleCarritos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleCarritoById(int id)
        {
            try
            {
                var result = await _service.GetDetalleCarritoById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddDetalleCarrito([FromBody] DetalleCarritoViewModel detalleCarrito)
        {
            try
            {
                DetalleCarrito newDetalleCarrito = new DetalleCarrito
                {
                    Cantidad = detalleCarrito.Cantidad,
                    CarritoId = detalleCarrito.CarritoId,
                    ProductoId = detalleCarrito.ProductoId,
                };

                var result = await _service.AddDetalleCarrito(newDetalleCarrito);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDetalleCarrito([FromBody] DetalleCarritoViewModel detalleCarrito)
        {
            try
            {
                DetalleCarrito newDetalleCarrito = new DetalleCarrito
                {
                    Id = detalleCarrito.Id,
                    Cantidad = detalleCarrito.Cantidad,
                    CarritoId = detalleCarrito.CarritoId,
                    ProductoId = detalleCarrito.ProductoId,
                };

                var result = await _service.UpdateDetalleCarrito(newDetalleCarrito);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCarrito(int id)
        {
            try
            {
                var result = await _service.DeleteDetalleCarrito(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
