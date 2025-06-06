using System.Collections.Generic;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformService _platformService;

    public PlatformController(IPlatformService platformService)
    {
        _platformService = platformService;
    }

    [HttpGet]
    public ActionResult<List<PlatformDTO>> GetAll() => _platformService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<PlatformDTO> Get(int id)
    {
        var platform = _platformService.Get(id);

        if (platform == null)
        {
            return NotFound();
        }
        else
        {
            return platform;
        }
    }

    // [HttpGet]
    // [Route("{id}/videogames")]
    // public ActionResult<List<VideogameDTO>> GetVideogamesByPlatform(int id)
    // {
    //     var videogames = _platformService.GetVideogamesByPlatform(id);

    //     if (videogames == null || videogames.Count == 0)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(videogames);


    // }
    // [HttpGet]
    // [Route("{id}/consoles")]
    // public ActionResult<List<ConsoleDTO>> GetConsolesByPlatform(int id)
    // {
    //     var consoles = _platformService.GetConsolesByPlatform(id);

    //     if (consoles == null || consoles.Count == 0)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(consoles);


    // }

    [HttpPost]
    public IActionResult Create([FromBody] PlatformCreateDTO platformCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _platformService.Add(platformCreateDTO);
        return Ok(platformCreateDTO);
    }

    [HttpGet("System/{id}")]
    public ActionResult<List<PlatformDTO>> GetPlatformsBySystem(int id)
    {
        var platformDTOs = _platformService.GetplatformsBySystem(id);

        if (platformDTOs == null || !platformDTOs.Any())
            return NotFound();

        return Ok(platformDTOs);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var platform = _platformService.Get(id);

        if (platform is null)
            return NotFound();

        _platformService.Delete(id);

        return NoContent();
    }

}





