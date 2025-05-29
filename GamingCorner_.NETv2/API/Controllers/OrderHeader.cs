using System.Security.Claims;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GamingCorner.Models.DTOs.ProductDTOs;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderHeaderController : ControllerBase
{
    private readonly IOrderHeaderService _orderHeaderService;

    public OrderHeaderController(IOrderHeaderService orderHeaderService)
    {
        _orderHeaderService = orderHeaderService;
    }

    [HttpGet]
    public ActionResult<List<OrderHeaderDTO>> GetAll() => _orderHeaderService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<OrderHeaderDTO> Get(int id)
    {
        var orderHeader = _orderHeaderService.Get(id);

        if (orderHeader == null)
        {
            return NotFound();
        }
        else
        {
            return orderHeader;
        }
    }


    [HttpPost]
    public IActionResult Create([FromBody] OrderHeaderCreateDTO orderHeaderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _orderHeaderService.Add(orderHeaderCreateDTO);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] OrderHeaderUpdateDTO orderHeaderUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _orderHeaderService.Update(id, orderHeaderUpdateDTO);
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
        var user = _orderHeaderService.Get(id);

        if (user is null)
            return NotFound();

        _orderHeaderService.Delete(id);

        return NoContent();
    }
}





