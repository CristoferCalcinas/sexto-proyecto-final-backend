using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _service;
        public CarritoController(ICarritoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCarritoCompras()
        {
            try
            {
                var carritoCompras = await _service.GetAllCarritoCompras();
                return Ok(carritoCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarritoCompraById(int id)
        {
            try
            {
                var carritoCompra = await _service.GetCarritoCompraById(id);
                return Ok(carritoCompra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCarritoCompra([FromBody] CarritoCompraViewModel carritoCompra)
        {
            try
            {
                Carrito newCarritoCompra = new Carrito
                {
                    ClienteId = carritoCompra.ClienteId,
                    FechaCreacion = carritoCompra.FechaCreación,
                    EstadoCarrito = carritoCompra.EstadoCarrito,
                };

                var result = await _service.AddCarritoCompra(newCarritoCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCarritoCompra([FromBody] CarritoCompraViewModel carritoCompra)
        {
            try
            {
                Carrito newCarritoCompra = new Carrito
                {
                    Id = carritoCompra.Id,
                    ClienteId = carritoCompra.ClienteId,
                    FechaCreacion = carritoCompra.FechaCreación,
                    EstadoCarrito = carritoCompra.EstadoCarrito,
                };

                var result = await _service.UpdateCarritoCompra(newCarritoCompra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarritoCompra(int id)
        {
            try
            {
                var result = await _service.DeleteCarritoCompra(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetAllWithDetailsCarritoCompras(int id)
        {
            try
            {
                var carritoCompras = await _service.GetAllWithDetailsCarritoCompras(id);
                return Ok(carritoCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
