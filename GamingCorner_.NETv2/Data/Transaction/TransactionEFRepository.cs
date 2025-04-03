    namespace GamingCorner.Data;

    using GamingCorner.Models;
    using System.Text.Json;
    using System.Data.SqlClient;
    using System.Data;
    using GamingCorner.Data;
    using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

public class TransactionEFRepository : ITransactionRepository
    {


        private readonly GamingCornerContext _context;

        public TransactionEFRepository(GamingCornerContext context)
        {

            _context = context;
        }

        public List<TransactionDTO> GetAll()
        {
            var transactions = _context.Transactions
                .ToList();

            if (transactions != null)
            {
                var transactionDto = transactions.Select(t => new TransactionDTO
                {
                    TransactionId = t.TransactionId,
                    UserId = t.UserId,
                    ProductId = t.ProductId,
                    VideogameId = t.VideogameId,
                    ConsoleId = t.ConsoleId,
                    Type = t.Type,
                    Date = t.Date,
                }).ToList();
                return transactionDto;
            }
            else
            {
                return null;
            }
        }

        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            SaveChanges();
        }

        public TransactionDTO Get(int id)
        {
            var transaction = _context.Transactions
                .Include(u => u.User)
                .Include(p => p.Product)
                .Include(v => v.Videogame)
                .Include(c => c.Console)
                .FirstOrDefault(t => t.TransactionId == id);

            if (transaction != null)
            {
                return new TransactionDTO
                {
                    TransactionId = transaction.TransactionId,
                    UserId = transaction.UserId,
                    ProductId = transaction.ProductId,
                    VideogameId = transaction.VideogameId,
                    ConsoleId = transaction.ConsoleId,
                    Type = transaction.Type,
                    Date = transaction.Date,
                };
            }
            else
            {
                return null;
            }
            
        }

        public void Update(Transaction transaction)
        {
            var existingTransaction = _context.Transactions.Find(transaction.TransactionId);

            if (existingTransaction != null)
            {
                _context.Entry(existingTransaction).CurrentValues.SetValues(transaction);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var transactionDto = Get(id);
            if (transactionDto == null)
            {
                throw new KeyNotFoundException("Transaction not found.");
            }
            var transaction = _context.Transactions.FirstOrDefault(t => t.TransactionId == id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                SaveChanges();
            }

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int CountTransactionsByVideogameId()
        {
            return _context.Transactions.Count(t => t.VideogameId.HasValue && t.Type == "Compra");
        }
        public int CountTransactionsByProductId()
        {
            return _context.Transactions.Count(t => t.ProductId.HasValue && t.Type == "Compra");
        }
        public int CountTransactionsByConsoleId()
        {
            return _context.Transactions.Count(t => t.ConsoleId.HasValue && t.Type == "Compra");
        }

    }
