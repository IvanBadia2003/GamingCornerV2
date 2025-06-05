using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class SecondHandProductController : ControllerBase
{
    private readonly ISecondHandProductService _secondHandProductService;

    public SecondHandProductController(ISecondHandProductService secondHandProductService)
    {
        _secondHandProductService = secondHandProductService;
    }

    [HttpGet]
    public ActionResult<List<SecondHandProductDTO>> GetAll() => _secondHandProductService.GetAll();
    
    [HttpGet]
    [Route("Checked")]

    public ActionResult<List<SecondHandProductDTO>> GetAllChecked() => _secondHandProductService.GetAllChecked();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<SecondHandProductDTO> Get(int id)
    {
        var product = _secondHandProductService.Get(id);

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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _secondHandProductService.Add(productCreateDTO);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] SecondHandProductUpdateDTO productUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
           return BadRequest(ModelState);
        }

        try
        {
            _secondHandProductService.Update(id, productUpdateDTO);
           return Ok();
        }
        catch (KeyNotFoundException)
        {
           return NotFound();
        }
        catch (Exception ex)
        {
           return BadRequest(ex.Message);
        }
    }
    
    
    [HttpPut("{id}/Checked")]
    public IActionResult CangeStatus(int id)
    {
        if (!ModelState.IsValid)
        {
           return BadRequest(ModelState);
        }

        try
        {
            _secondHandProductService.CangeStatus(id);
           return Ok();
        }
        catch (KeyNotFoundException)
        {
           return NotFound();
        }
        catch (Exception ex)
        {
           return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var product = _secondHandProductService.Get(id);

        if (product is null)
            return NotFound();

        _secondHandProductService.Delete(id);

        return NoContent();
    }
}
