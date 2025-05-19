using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsoleController : ControllerBase
{
    private readonly IConsoleService _consoleService;

    public ConsoleController(IConsoleService consoleService)
    {
        _consoleService = consoleService;
    }

    [HttpGet]
    public ActionResult<List<ConsoleDTO>> GetAll() => _consoleService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ConsoleDTO> Get(int id)
    {
        var console = _consoleService.Get(id);

        if (console == null)
        {
           return NotFound();
        }
        else
        {
           return console;
        }
    }



    [HttpPost]
    public IActionResult Create([FromBody] ConsoleCreateDTO consoleCreateDTO)
    {
        if (!ModelState.IsValid)
        {
           return BadRequest(ModelState);
        }
        _consoleService.Add(consoleCreateDTO);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ConsoleUpdateDTO consoleUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
           return BadRequest(ModelState);
        }

        try
        {
           _consoleService.Update(id, consoleUpdateDTO);
           return NoContent();
        }
        catch (KeyNotFoundException)
        {
           return NotFound();
        }
        return Ok();

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var console = _consoleService.Get(id);

        if (console is null)
            return NotFound();

        _consoleService.Delete(id);

        return NoContent();
    }
}





