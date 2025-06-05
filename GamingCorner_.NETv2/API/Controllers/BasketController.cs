using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet]
    public ActionResult<List<BasketDTO>> GetAll() =>
    _basketService.GetAll();



    [HttpGet]
    [Route("User/{idUser}")]
    public ActionResult<List<BasketDTO>> Get(int idUser)
    {
        var basket = _basketService.Get(idUser);

        if (basket == null){
            return NotFound();
        }else{
            return basket;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] BasketCreateDTO basketCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _basketService.Add(basketCreateDTO);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            // Conflicto: el producto ya estaba en el carrito
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Otro error inesperado
            return StatusCode(500, new { message = "Error interno del servidor", details = ex.Message });
        }
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
        var basket = _basketService.Get(idUser, idProduct);

        if (basket is null)
            return NotFound();

        _basketService.Delete(idUser, idProduct);

        return NoContent();
    }
}