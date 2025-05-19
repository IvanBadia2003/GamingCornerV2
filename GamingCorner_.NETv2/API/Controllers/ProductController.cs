using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obterner lista de todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProductDTOBase>> GetAll() => _productService.GetAll();


        /// <summary>
        /// Obtener producto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductDTOBase> Get(int id)
        {
            try
            {
                // Obtenemos el producto
                var product = _productService.Get(id);

                // Si existe
                return Ok(product);

            }
            // Si no existe
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            // Otro fallo
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Crear producto (No hace falta usar)
        /// </summary>
        /// <param name="videogameCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] ProductDTOBase videogameCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.Add(videogameCreateDTO);
            return Ok();
        }


        /// <summary>
        /// Actualizar producto (No hace falta usar)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="videogameUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTOBase videogameUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.Update(id, videogameUpdateDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Borrar producto (Solo si eres Admin)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // Obtenemos producto
            var product = _productService.Get(id);

            // si no existe
            if (product is null)
                return NotFound();

            // Eliminamos producto
            _productService.Delete(id);

            // Exito 
            return NoContent();
        }
    }
}
