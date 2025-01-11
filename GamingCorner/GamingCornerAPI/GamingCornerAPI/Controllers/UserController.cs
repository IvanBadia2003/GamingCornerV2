using Microsoft.AspNetCore.Mvc;
using GamingCornerAPI.Application.Main.UserServices;
using GamingCornerAPI.Application.DTO.UserDTOs;


namespace GamingCornerAPI.Presentation.MVC.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                UserDTO userDTO = _userService.getUserById(id);

                if (userDTO == null)
                {
                    return NotFound(new { message = "No se encontró un usuario con el estado especificado." });
                }
                else
                {
                    return Ok(userDTO);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                       new { message = "Ocurrió un error inesperado al procesar la solicitud." });
            }
        }

        // GET api/<UserController>/1
        [HttpGet("activate/{actived}")]
        public ActionResult IsActivate(bool actived)
        {
            try
            {
                UserDTO userDTO = _userService.getUserByActive(actived);

                if (userDTO == null)
                {
                    return NotFound(new { message = "No se encontró un usuario con el estado especificado." });
                }
                else
                {
                    return Ok(userDTO);
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                       new { message = "Ocurrió un error inesperado al procesar la solicitud." });
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
