using RushToWin.API.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Repositories
{
    public interface IWalletRepository
    {
        Task<Wallet> Insert(Wallet entity);
        Task<Wallet> Get(Guid id);
        Task<Wallet> Update(Wallet wallet);
    }
}
