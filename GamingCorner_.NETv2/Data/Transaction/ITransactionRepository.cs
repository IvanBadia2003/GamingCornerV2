using GamingCorner.Models;

namespace GamingCorner.Data;

public interface ITransactionRepository
{
    List<TransactionDTO> GetAll();
    // GetAll(int id);
    void Add(Transaction transaction);
    TransactionDTO Get(int id);
    void Update(Transaction transaction);
    void Delete(int id);

    int CountTransactionsByVideogameId();
    int CountTransactionsByProductId();
    int CountTransactionsByConsoleId();

}