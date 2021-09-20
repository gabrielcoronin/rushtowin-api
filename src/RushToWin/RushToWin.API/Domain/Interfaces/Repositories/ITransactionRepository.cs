using RushToWin.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> Insert(Transaction entity);
        Task<IEnumerable<Transaction>> List();

    }
}
