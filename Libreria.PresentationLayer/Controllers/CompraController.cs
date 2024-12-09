using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;
        public CompraController(ICompraService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCompras()
        {
            try
            {
                var compras = await _service.GetAllCompras();
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompraById(int id)
        {
            try
            {
                var compra = await _service.GetCompraById(id);
                return Ok(compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCompra([FromBody] ComprasViewModel compra)
        {
            try
            {
                var producto = await _service.GetProduct(compra.ProductoId);
                if (producto == null)
                {
                    return NotFound();
                }

                Compra newCompra = new Compra
                {
                    UsuarioId = compra.ClienteId,
                    Estado = compra.Estado,
                    FechaCompra = DateOnly.FromDateTime(DateTime.Now),
                    TotalCompra = compra.Cantidad * producto.Precio,
                };

                var result = await _service.AddCompra(newCompra);


                DetalleCompra newDetalleCompra = new DetalleCompra
                {
                    CompraId = result.Id,
                    ProductoId = compra.ProductoId,
                    Cantidad = compra.Cantidad,
                    PrecioUnitario = producto.Precio,
                    Subtotal = result.TotalCompra,
                };

                var newResult = await _service.AddDetalleCompra(newDetalleCompra);

                return Ok(newResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompra([FromBody] ComprasViewModel compra)
        {
            try
            {
                var compraToDatabase = await _service.GetCompraById(compra.Id);

                if (compraToDatabase != null)
                {
                    Compra newCompra = new Compra
                    {
                        Id = compraToDatabase.Id,
                        UsuarioId = compraToDatabase.UsuarioId,
                        Estado = compra.Estado,
                        FechaCompra = compraToDatabase.FechaCompra,
                        TotalCompra = compraToDatabase.TotalCompra,
                    };
                    var result = await _service.UpdateCompra(newCompra);
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            try
            {
                var result = await _service.DeleteCompra(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
