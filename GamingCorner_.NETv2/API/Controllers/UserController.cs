using System.Security.Claims;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll() => _userService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<UserDTO> Get(int id)
    {
        var user = _userService.Get(id);

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
    public IActionResult Create([FromBody] UserCreateDTO userCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _userService.Add(userCreateDTO);
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
    public IActionResult Update(int id, [FromBody] UserUpdateDTO userUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _userService.Update(id, userUpdateDTO);
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
        var user = _userService.Get(id);

        if (user is null)
            return NotFound();

        _userService.Delete(id);

        return NoContent();
    }

    [HttpPost("login")] // Ruta del endpoint para el inicio de sesión
    public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Devuelve error 400 si el modelo no es válido
        }

        try
        {
            // Llama al servicio de autenticación para manejar el inicio de sesión
            var user = _userService.Login(userLoginDTO.Email, userLoginDTO.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas. Por favor, verifique su correo y contraseña." }); // Devuelve un Unauthorized con mensaje si las credenciales son incorrectas
            }

            var role = user.Admin ? "Admin" : "User";

            // Devuelve un Ok con el objeto UserDTO si el inicio de sesión es exitoso
            // Claims del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("UserId", user.UserId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Crear la cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Ok(new { message = "Sesión iniciada", user });
        }
        catch (Exception ex)
        {
            // Captura cualquier error inesperado y devuelve un InternalServerError con el mensaje de la excepción
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor. Inténtelo nuevamente más tarde.", details = ex.Message });
        }
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult Me()
    {
        try
        {
            var UserId = int.Parse(User.FindFirst("UserId")?.Value);
            var user = Get(UserId);
            return Ok(user);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Ok("Sesión cerrada");
    }

}





