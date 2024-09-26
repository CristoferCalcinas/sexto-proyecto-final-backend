using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoProveedorController : ControllerBase
    {
        private readonly IPedidoProveedorService _service;
        public PedidoProveedorController(IPedidoProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidoProveedor()
        {
            var pedidoProveedor = await _service.GetAllPedidoProveedor();
            return Ok(pedidoProveedor);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoProveedorById(int id)
        {
            var pedidoProveedor = await _service.GetPedidoProveedorById(id);
            return Ok(pedidoProveedor);
        }

        [HttpPost]
        public async Task<IActionResult> AddPedidoProveedor([FromBody] PedidoProveedorViewModel pedidoProveedor)
        {
            PedidoProveedor newPedidoProveedor = new PedidoProveedor
            {
                EstadoPedido = pedidoProveedor.EstadoPedido,
                FechaPedido = pedidoProveedor.FechaPedido,
                ProveedorId = pedidoProveedor.ProveedorId,
                TotalPedido = pedidoProveedor.TotalPedido
            };

            var addedPedidoProveedor = await _service.AddPedidoProveedor(newPedidoProveedor);
            return Ok(addedPedidoProveedor);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedidoProveedor([FromBody] PedidoProveedorViewModel pedidoProveedor)
        {
            var pedidoProveedorToUpdate = await _service.GetPedidoProveedorById(pedidoProveedor.Id);
            if (pedidoProveedorToUpdate == null)
            {
                return NotFound();
            }

            pedidoProveedorToUpdate.EstadoPedido = pedidoProveedor.EstadoPedido;
            pedidoProveedorToUpdate.FechaPedido = pedidoProveedor.FechaPedido;
            pedidoProveedorToUpdate.ProveedorId = pedidoProveedor.ProveedorId;
            pedidoProveedorToUpdate.TotalPedido = pedidoProveedor.TotalPedido;

            var updatedPedidoProveedor = await _service.UpdatePedidoProveedor(pedidoProveedorToUpdate);
            return Ok(updatedPedidoProveedor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoProveedor(int id)
        {
            var pedidoProveedor = await _service.DeletePedidoProveedor(id);
            return Ok(pedidoProveedor);
        }
    }
}
