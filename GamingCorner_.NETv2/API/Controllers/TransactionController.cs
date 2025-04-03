using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public ActionResult<List<TransactionDTO>> GetAll() => _transactionService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<TransactionDTO> Get(int id)
    {
        var transaction = _transactionService.Get(id);

        if (transaction == null)
        {
            return NotFound();
        }
        else
        {
            return transaction;
        }
    }

    [HttpGet("user/{userId}")]
    public ActionResult<List<TransactionDTO>> GetTransactionsByUserId(int userId)
    {
        var transactions = _transactionService.Get(userId);
        if (transactions == null)
        {
            return NotFound();
        }

        return Ok(transactions);
    }

    [HttpPost("compra/user/{userId}/product/{productId}")]
    public ActionResult PurchaseProduct(int userId, int productId)
    {
        _transactionService.RegisterPurchaseProduct(userId, productId);
        return Ok();
    }
    
    [HttpPost("compra/user/{userId}/videgame/{videogameId}")]
    public ActionResult PurchaseVideogame(int userId, int videogameId)
    {
        _transactionService.RegisterPurchaseVideogame(userId, videogameId);
        return Ok();
    }
    
    [HttpPost("compra/user/{userId}/console/{consoleId}")]
    public ActionResult PurchaseConsole(int userId, int consoleId)
    {
        _transactionService.RegisterPurchaseConsole(userId, consoleId);
        return Ok();
    }
    [HttpPost("sell/user/{userId}/product")]
    public ActionResult SellProduct(int userId, [FromBody] ProductCreateDTO productCreateDTO)
    {
        var product = new Product
        {
            Name = productCreateDTO.Name,
            Description = productCreateDTO.Description,
            Price = productCreateDTO.Price,
            Available = productCreateDTO.Available,
            ImageURL = productCreateDTO.ImageURL
        };
        _transactionService.SellProduct(userId, product);
        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] TransactionCreateDTO transactionCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _transactionService.Add(transactionCreateDTO);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var transaction = _transactionService.Get(id);

        if (transaction is null)
            return NotFound();

        _transactionService.Delete(id);

        return NoContent();
    }

    [HttpGet("counTransactionsByVideogameId")]
    public IActionResult CountTransactionsByVideogameId()
    {
        var count = _transactionService.CountTransactionsByVideogameId();
        return Ok(count);
    }
    [HttpGet("CountTransactionsByProductId")]
    public IActionResult CountTransactionsByProductId()
    {
        var count = _transactionService.CountTransactionsByProductId();
        return Ok(count);
    }
    [HttpGet("CountTransactionsByConsoleId")]
    public IActionResult CountTransactionsByConsoleId()
    {
        var count = _transactionService.CountTransactionsByConsoleId();
        return Ok(count);
    }

}





