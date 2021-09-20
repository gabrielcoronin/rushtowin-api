using RushToWin.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> List(Guid id);
        Task<Transaction> Recharge(double value, Guid id);
        Task<Transaction> Bus(Guid id);
        Task<Transaction> Subway(Guid id);
        Task<Transaction> Train(Guid id);

    }
}
