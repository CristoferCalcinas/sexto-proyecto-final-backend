using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCompraController : ControllerBase
    {
        private readonly IDetalleCompraService _service;
        public DetalleCompraController(IDetalleCompraService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDetalleCompras()
        {
            try
            {
                var detalleCompras = await _service.GetAllDetalleCompras();
                return Ok(detalleCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleCompraById(int id)
        {
            try
            {
                var detalleCompra = await _service.GetDetalleCompraById(id);
                return Ok(detalleCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddDetalleCompra([FromBody] DetalleCompraViewModel detalleCompra)
        {
            try
            {
                DetalleCompra newDetalleCompra = new DetalleCompra
                {
                    Cantidad = detalleCompra.Cantidad,
                    CompraId = detalleCompra.CompraId,
                    ProductoId = detalleCompra.ProductoId,
                };

                var result = await _service.AddDetalleCompra(newDetalleCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDetalleCompra([FromBody] DetalleCompraViewModel detalleCompra)
        {
            try
            {
                DetalleCompra newDetalleCompra = new DetalleCompra
                {
                    Id = detalleCompra.Id,
                    Cantidad = detalleCompra.Cantidad,
                    CompraId = detalleCompra.CompraId,
                    ProductoId = detalleCompra.ProductoId,
                };

                var result = await _service.UpdateDetalleCompra(newDetalleCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCompra(int id)
        {
            try
            {
                var result = await _service.DeleteDetalleCompra(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
