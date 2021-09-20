using Microsoft.EntityFrameworkCore;
using RushToWin.API.Data.Context;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyDbContext _context;

        public TransactionRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> Insert(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> List()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
