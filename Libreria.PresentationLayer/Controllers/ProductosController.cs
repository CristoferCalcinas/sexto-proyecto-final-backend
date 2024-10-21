using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _service;
        public ProductosController(IProductosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            var productos = await _service.GetAllProductos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            var producto = await _service.GetProductorById(id);
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProducto([FromBody] ProductoViewModel producto)
        {
            Producto newProducto = new Producto
            {
                Id = producto.Id,
                NombreProducto = producto.NombreProducto,
                Descripcion = producto.Descripción,
                Precio = producto.Precio,
                CantidadStock = producto.CantidadStock,
            };

            var addedProducto = await _service.AddProducto(newProducto);
            return Ok(addedProducto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] ProductoViewModel producto)
        {
            var productoToUpdate = await _service.GetProductorById(producto.Id);
            if ( productoToUpdate == null)
            {
                return NotFound();
            }

            productoToUpdate.NombreProducto = producto.NombreProducto;
            productoToUpdate.Descripcion = producto.Descripción;
            productoToUpdate.Precio = producto.Precio;
            productoToUpdate.CantidadStock = producto.CantidadStock;

            var updatedProducto = await _service.UpdateProducto(productoToUpdate);
            return Ok(updatedProducto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var deletedProducto = await _service.DeleteProducto(id);
            return Ok(deletedProducto);
        }
    }
}
