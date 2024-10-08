using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _service;
        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProveedores()
        {
            var proveedores = await _service.GetAllProveedores();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProveedorById(int id)
        {
            var proveedor = await _service.GetProveedorById(id);
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> AddProveedor([FromBody] ProveedorViewModel proveedor)
        {
            Proveedor proveedorToAdd = new Proveedor
            {
                CorreoElectrónico = proveedor.CorreoElectrónico,
                Dirección = proveedor.Dirección,
                Teléfono = proveedor.Teléfono,
            };
            var result = await _service.AddProveedor(proveedorToAdd);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProveedor([FromBody] ProveedorViewModel proveedor)
        {
            var proveedorToDatabase = await _service.GetProveedorById(proveedor.Id);
            if (proveedorToDatabase == null)
            {
                return NotFound();
            }
            proveedorToDatabase.CorreoElectrónico = proveedor.CorreoElectrónico;
            proveedorToDatabase.Dirección = proveedor.Dirección;
            proveedorToDatabase.Id = proveedor.Id;
            proveedorToDatabase.Teléfono = proveedor.Teléfono;
            var result = await _service.UpdateProveedor(proveedorToDatabase);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await _service.GetProveedorById(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            var result = await _service.DeleteProveedor(id);
            return Ok(result);
        }
    }
}
