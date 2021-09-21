using RushToWin.API.Domain.Entities;
using RushToWin.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<Wallet> Get(Guid id);
        Task<IEnumerable<Transaction>> List(Guid id);
        Task<Transaction> Recharge(double value, Guid id);
        Task<Notification> Bus(Guid id);
        Task<Notification> Subway(Guid id);
        Task<Notification> Train(Guid id);

    }
}
