using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class FavouriteController : ControllerBase
{
    private readonly IFavouriteService _favouriteService;
    public FavouriteController(IFavouriteService favouriteService)
    {
        _favouriteService = favouriteService;
    }

    [HttpGet]
    public ActionResult<List<FavouriteDTO>> GetAll() =>
    _favouriteService.GetAll();



    [HttpGet]
    [Route("User/{idUser}")]
    public ActionResult<List<FavouriteDTO>> Get(int idUser)
    {
        var favourite = _favouriteService.Get(idUser);

        if (favourite == null){
            return NotFound();
        }else{
            return favourite;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] FavouriteCreateDTO favouriteCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _favouriteService.Add(favouriteCreateDTO);
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




    [HttpDelete("User/{idUser}/Product/{idProduct}")]
    public IActionResult Delete(int idUser, int idProduct)
    {
        var favourite = _favouriteService.Get(idUser, idProduct);

        if (favourite is null)
            return NotFound();

        _favouriteService.Delete(idUser, idProduct);

        return NoContent();
    }
}