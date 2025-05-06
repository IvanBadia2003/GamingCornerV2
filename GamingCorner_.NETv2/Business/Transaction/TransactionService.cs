namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class TransactionService : ITransactionService
{

    private readonly ITransactionRepository _transactionRepository;
    private readonly IVideogameRepository _videogameRepository;
    private readonly IConsoleRepository _consoleRepository;
    private readonly IProductRepository _productRepository;


    public TransactionService(ITransactionRepository transactionRepository,IVideogameRepository videogameRepository, IConsoleRepository consoleRepository, IProductRepository productRepository)
    {
        _transactionRepository = transactionRepository;
        _videogameRepository = videogameRepository;
        _consoleRepository = consoleRepository;
        _productRepository = productRepository;

    }
    public List<TransactionDTO> GetAll()
    {
        var transactions = _transactionRepository.GetAll();
        return transactions;
    }

    public void RegisterPurchaseProduct (int userId, int productId)
    {
        var transaction = new Transaction(userId, productId,null,null, "Compra", DateTime.Now);
        _transactionRepository.Add(transaction);
    }
    public void RegisterPurchaseVideogame (int userId, int videogameId)
    {
        var transaction = new Transaction(userId, null,videogameId,null, "Compra", DateTime.Now);
        _transactionRepository.Add(transaction);
    }
    
    public void RegisterPurchaseConsole (int userId, int consoleId)
    {
        var transaction = new Transaction(userId, null,null,consoleId, "Compra", DateTime.Now);
        _transactionRepository.Add(transaction);
    }
    public void SellProduct (int userId, Product product)
    {
        _productRepository.Add(product);
        var transaction = new Transaction(userId, product.ProductId,null,null, "Venta", DateTime.Now);
        _transactionRepository.Add(transaction);
    }

    public TransactionDTO Get(int id)
    {
        var transaction = _transactionRepository.Get(id);
        return transaction;
    }
    public TransactionDTO GetTransactionById(int id)
    {
        return _transactionRepository.Get(id);
    }

    public void Add(TransactionCreateDTO transactionCreateDTO)
    {
        var transaction = new Transaction();
        var mappedTransaction = transaction.mapFromCreateDto(transactionCreateDTO);
        _transactionRepository.Add(mappedTransaction);
    }


    public void Delete(int id)
    {
        _transactionRepository.Delete(id);
    }

    public int CountTransactionsByVideogameId()
    {
        return _transactionRepository.CountTransactionsByVideogameId();
    }
    public int CountTransactionsByProductId()
    {
        return _transactionRepository.CountTransactionsByProductId();
    }
    public int CountTransactionsByConsoleId()
    {
        return _transactionRepository.CountTransactionsByConsoleId();
    }

}


    
    

