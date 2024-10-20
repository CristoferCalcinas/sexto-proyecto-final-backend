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
                Compra newCompra = new Compra
                {
                    ClienteId = compra.ClienteId,
                    Estado = compra.Estado,
                    FechaCompra = compra.FechaCompra,
                    TotalCompra = compra.TotalCompra,
                };

                var result = await _service.AddCompra(newCompra);
                return Ok(result);
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
                Compra newCompra = new Compra
                {
                    Id = compra.Id,
                    ClienteId = compra.ClienteId,
                    Estado = compra.Estado,
                    FechaCompra = compra.FechaCompra,
                    TotalCompra = compra.TotalCompra,
                };

                var result = await _service.UpdateCompra(newCompra);
                return Ok(result);
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
