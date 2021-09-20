using RushToWin.API.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Services
{
    public interface IWalletService
    {
        Task<Wallet> Insert(Wallet entity);
        Task<Wallet> Get(Guid id);       
        Task<Wallet> Update(Wallet wallet);
    }
}
