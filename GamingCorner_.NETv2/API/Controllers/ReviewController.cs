using GamingCorner.Business;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ReviewDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService service)
        {
            _reviewService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var reviews = _reviewService.GetAll();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                // Aquí podrías loggear ex.InnerException y luego devolver un error 500
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet("User/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            try
            {
                var reviews = _reviewService.GetByUserId(userId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpGet("Product/{productId}")]
        public IActionResult GetByProduct(int productId)
        {
            try
            {
                var reviews = _reviewService.GetByProductId(productId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        
        
        [HttpGet("AverageRating/{productId}")]
        public IActionResult AverageRating(int productId)
        {
            try
            {
                var averageRating = _reviewService.AverageRating(productId);
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReviewCreateDTO reviewDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _reviewService.Create(reviewDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _reviewService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
