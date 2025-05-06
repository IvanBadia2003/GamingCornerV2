using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<ProductDTO>> GetAll() => _productService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProductDTO> Get(int id)
    {
        var product = _productService.Get(id);

        if (product == null)
        {
            return NotFound();
        }
        else
        {
            return product;
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateDTO productCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _productService.Add(productCreateDTO);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ProductUpdateDTO productUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _productService.Update(id, productUpdateDTO);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _productService.Get(id);

        if (product is null)
            return NotFound();

        _productService.Delete(id);

        return NoContent();
    }
}
