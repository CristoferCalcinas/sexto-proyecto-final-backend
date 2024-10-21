using Libreria.BusinessLogicLayer.Servicios.Contracts;
using Libreria.Models;
using Libreria.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoríaController : ControllerBase
    {
        private readonly ICategoríaService _service;
        public CategoríaController(ICategoríaService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategorías()
        {
            try
            {
                var categorías = await _service.GetAllCategorías();
                return Ok(categorías);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoríaById(int id)
        {
            try
            {
                var categoría = await _service.GetCategoríaById(id);
                return Ok(categoría);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddCategoría([FromBody] CategoríaViewModel categoría)
        {
            try
            {
                Categorium newCategoría = new Categorium
                {
                    Descripcion = categoría.Descripcion,
                    NombreCategoria = categoría.NombreCategoria,
                };

                var result = await _service.AddCategoría(newCategoría);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategoría([FromBody] CategoríaViewModel categoría)
        {
            try
            {
                Categorium newCategoría = new Categorium
                {
                    Id = categoría.Id,
                    Descripcion = categoría.Descripcion,
                    NombreCategoria = categoría.NombreCategoria,
                };

                var result = await _service.UpdateCategoría(newCategoría);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoría(int id)
        {
            try
            {
                var result = await _service.DeleteCategoría(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
