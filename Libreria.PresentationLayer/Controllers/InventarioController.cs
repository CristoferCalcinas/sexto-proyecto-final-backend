using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioService _service;
        public InventarioController(IInventarioService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInventarios()
        {
            try
            {
                var inventarios = await _service.GetAllInventarios();
                return Ok(inventarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventarioById(int id)
        {
            try
            {
                var inventario = await _service.GetInventarioById(id);
                return Ok(inventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddInventario([FromBody] InventarioViewModel inventario)
        {
            try
            {
                Inventario newInventario = new Inventario
                {
                    CantidadEntrante = inventario.CantidadEntrante,
                    FechaEntrada = inventario.FechaEntrada,
                    ProductoId = inventario.ProductoId,
                };

                var result = await _service.AddInventario(newInventario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateInventario([FromBody] InventarioViewModel inventario)
        {
            try
            {
                Inventario newInventario = new Inventario
                {
                    Id = inventario.Id,
                    CantidadEntrante = inventario.CantidadEntrante,
                    FechaEntrada = inventario.FechaEntrada,
                    ProductoId = inventario.ProductoId,
                };

                var result = await _service.UpdateInventario(newInventario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            try
            {
                var result = await _service.DeleteInventario(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
