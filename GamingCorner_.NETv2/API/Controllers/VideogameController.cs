using System.Linq;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class VideogameController : ControllerBase
{
    private readonly IVideogameService _videogameService;
    private readonly IVideogameGenderService _videogameGenderService;

    public VideogameController(IVideogameService videogameService, IVideogameGenderService videogameGenderService)
    {
        _videogameService = videogameService;
        _videogameGenderService = videogameGenderService;
    }


    [HttpGet]
    public ActionResult<List<VideogameDTO>> GetAll() => _videogameService.GetAll();

    [HttpPost("Filter")]
    public ActionResult<List<VideogameDTO>> GetFiltered([FromBody] VideogameFilterDto filters) => _videogameService.GetFiltered(filters);

    [HttpGet]
    [Route("{id}")]
    public ActionResult<VideogameDTO> Get(int id)
    {
        var user = _videogameService.Get(id);

        if (user == null)
        {
            return NotFound();
        }
        else
        {
            return user;
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] VideogameCreateDTO videogameCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        VideogameDTO videogameCreated = _videogameService.Add(videogameCreateDTO);


        foreach (var genderId in videogameCreateDTO.GenderId)
        {
            VideogameGenderCreateDTO videogameGenderDto = new VideogameGenderCreateDTO
            {
                GenderId = genderId,
                VideogameId = videogameCreated.Id
            };

            _videogameGenderService.Add(videogameGenderDto);
        }
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] VideogameUpdateDTO videogameUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            //Hacemos el update del juego
            _videogameService.Update(id, videogameUpdateDTO);

            //Obtenemos todos los generos que hay en la base de datos
            List<VideogameGenderDTO> gendersInBD = _videogameGenderService.GetGendersByVideogameId(id).ToList();
            //Obtenemos solamente los ids de los generos
            List<int> gendersInDbIds = gendersInBD.Select(g => g.GenderId).ToList();
            //Obtenemos los ids que se van a borrar
            List<int> gendersToDelete = gendersInDbIds.Except(videogameUpdateDTO.GenderId).ToList();
            //Obtenemos los ids que se van a añadir
            List<int> gendersToAdd = videogameUpdateDTO.GenderId.Except(gendersInDbIds).ToList();
            //Borramos los generos
            foreach (var genderId in gendersToDelete)
            {
                _videogameGenderService.Delete(genderId, id);
            }
            //Añadimos los generosç
            foreach (var genderId in gendersToAdd)
            {
                VideogameGenderCreateDTO videogameGenderDto = new VideogameGenderCreateDTO
                {
                    GenderId = genderId,
                    VideogameId = id
                };

                _videogameGenderService.Add(videogameGenderDto);
            }

            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
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
        var videogame = _videogameService.Get(id);

        if (videogame is null)
            return NotFound();

        _videogameService.Delete(id);

        return NoContent();
    }
}
