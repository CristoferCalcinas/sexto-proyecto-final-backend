using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            try
            {
                // Validaciones básicas
                if (producto == null)
                    return BadRequest("El producto no puede ser nulo");

                if (string.IsNullOrWhiteSpace(producto.NombreProducto))
                    return BadRequest("El nombre del producto es requerido");

                if (producto.Precio <= 0)
                    return BadRequest("El precio debe ser mayor a 0");

                if (producto.CantidadStock <= 0)
                    return BadRequest("La cantidad en stock no puede ser negativa");

                var newProducto = new Producto
                {
                    CantidadStock = producto.CantidadStock,
                    CategoriaId = producto.CategoriaId,
                    Descripcion = producto.Descripcion,
                    FechaIngreso = DateOnly.FromDateTime(DateTime.Now),
                    NombreProducto = producto.NombreProducto.Trim(),
                    Precio = producto.Precio,
                    ProveedorId = producto.ProveedorId
                };

                var addedProducto = await _service.AddProducto(newProducto);
                return CreatedAtAction(nameof(GetProductoById), new { id = addedProducto.Id }, addedProducto);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, $"Error interno al procesar la solicitud \n{ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducto([FromBody] ProductoViewModel producto)
        {
            var productoToUpdate = await _service.GetProductorById(producto.Id);
            if (productoToUpdate == null)
            {
                return NotFound();
            }

            productoToUpdate.NombreProducto = producto.NombreProducto;
            productoToUpdate.Descripcion = producto.Descripcion;
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

        [HttpGet("search/{nameProduct}")]
        public async Task<IActionResult> GetProductosByName(string nameProduct)
        {
            var productos = await _service.GetProductosByName(nameProduct);
            return Ok(productos);
        }

        [HttpPatch("reduceToCart")]
        public async Task<IActionResult> ReduceProductQuantity([FromBody] List<ReduceProductQuantity> reduceProductQuantityList)
        {
            try
            {
                if(reduceProductQuantityList.IsNullOrEmpty())
                    return BadRequest("La lista de productos a reducir no puede ser nula o vacía");

                if(reduceProductQuantityList.Any(x => x.Cantidad <= 0))
                    return BadRequest("La cantidad de productos a reducir debe ser mayor a 0");

                var productos = await _service.ReduceProductQuantity(reduceProductQuantityList);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
