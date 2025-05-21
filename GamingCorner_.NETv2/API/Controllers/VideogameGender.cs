using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class VideogameGenderController : ControllerBase
{
    private readonly IVideogameGenderService _videogameGenderService;
    public VideogameGenderController(IVideogameGenderService videogameGenderService)
    {
        _videogameGenderService = videogameGenderService;
    }

    [HttpGet]
    public ActionResult<List<VideogameGenderDTO>> GetAll() =>
    _videogameGenderService.GetAll();



    [HttpGet]
    [Route("Gender/{idGender}/Videogame/{idVideogame}")]
    public ActionResult<VideogameGenderDTO> Get(int idGender, int idVideogame)
    {
        var gender = _videogameGenderService.Get(idGender, idVideogame);

        if (gender == null){
            return NotFound();
        }else{
            return gender;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] VideogameGenderCreateDTO videogameGenderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _videogameGenderService.Add(videogameGenderCreateDTO);
        return Ok();
    }




    // [HttpPut("{id}")]
    // public IActionResult Update(int id, [FromBody] VideogameUpdateDTO videogameUpdateDTO)
    // {
    //     if (!ModelState.IsValid) { return BadRequest(ModelState); }

    //     try
    //     {
    //         _genderService.Update(id, videogameUpdateDTO);
    //         return NoContent();
    //     }
    //     catch (KeyNotFoundException)
    //     {
    //         return NotFound();
    //     }
    // }




    [HttpDelete("{id}")]
    public IActionResult Delete(int idGender, int idVideogame)
    {
        var user = _videogameGenderService.Get(idGender, idVideogame);

        if (user is null)
            return NotFound();

        _videogameGenderService.Delete(idGender, idVideogame);

        return NoContent();
    }
}