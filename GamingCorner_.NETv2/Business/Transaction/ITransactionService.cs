namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface ITransactionService
{
    List<TransactionDTO> GetAll();
    // GetAll(int id);
    void Add(TransactionCreateDTO transactionCreateDTO);
    TransactionDTO Get(int id);
    void RegisterPurchaseVideogame(int userId, int videogameId);
    void RegisterPurchaseConsole(int userId, int consoleId);
    void RegisterPurchaseProduct(int userId, int productId);
    void SellProduct(int userId, Product product);
    void Delete(int id);
    int CountTransactionsByVideogameId();
    int CountTransactionsByProductId();
    int CountTransactionsByConsoleId();

}
