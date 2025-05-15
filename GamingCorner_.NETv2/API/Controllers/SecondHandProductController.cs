using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class SecondHandProductController : ControllerBase
{
    private readonly ISecondHandProductService _productService;

    public SecondHandProductController(ISecondHandProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<SecondHandProductDTO>> GetAll() => _productService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<SecondHandProductDTO> Get(int id)
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
    public IActionResult Create([FromBody] SecondHandProductCreateDTO productCreateDTO)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}
        //_productService.Add(productCreateDTO);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] SecondHandProductUpdateDTO productUpdateDTO)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        //try
        //{
        //    _productService.Update(id, productUpdateDTO);
        //    return NoContent();
        //}
        //catch (KeyNotFoundException)
        //{
        //    return NotFound();
        //}
        return Ok();

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
