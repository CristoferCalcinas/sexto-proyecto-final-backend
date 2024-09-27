using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoProveedorController : ControllerBase
    {
        private readonly IDetallePedidoProveedorService _service;
        public DetallePedidoProveedorController(IDetallePedidoProveedorService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDetallePedidoProveedores()
        {
            try
            {
                var detallePedidoProveedores = await _service.GetAllDetallePedidoProveedores();
                return Ok(detallePedidoProveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetallePedidoProveedorById(int id)
        {
            try
            {
                var detallePedidoProveedor = await _service.GetDetallePedidoProveedorById(id);
                return Ok(detallePedidoProveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddDetallePedidoProveedor([FromBody] DetallePedidoProveedorViewModel detallePedidoProveedor)
        {
            try
            {
                DetallePedidoProveedor newDetallePedidoProveedor = new DetallePedidoProveedor
                {
                    Cantidad = detallePedidoProveedor.Cantidad,
                    PedidoProveedorId = detallePedidoProveedor.PedidoProveedorId,
                    ProductoId = detallePedidoProveedor.ProductoId,                    
                };

                var result = await _service.AddDetallePedidoProveedor(newDetallePedidoProveedor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDetallePedidoProveedor([FromBody] DetallePedidoProveedorViewModel detallePedidoProveedor)
        {
            try
            {
                DetallePedidoProveedor newDetallePedidoProveedor = new DetallePedidoProveedor
                {
                    Id = detallePedidoProveedor.Id,
                    Cantidad = detallePedidoProveedor.Cantidad,
                    PedidoProveedorId = detallePedidoProveedor.PedidoProveedorId,
                    ProductoId = detallePedidoProveedor.ProductoId,
                };

                var result = await _service.UpdateDetallePedidoProveedor(newDetallePedidoProveedor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedidoProveedor(int id)
        {
            try
            {
                var result = await _service.DeleteDetallePedidoProveedor(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
