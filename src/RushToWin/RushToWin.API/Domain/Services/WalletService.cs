using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public Task<Wallet> Insert(Wallet entity)
        {
            return _walletRepository.Insert(entity);
        }

        public Task<Wallet> Get(Guid id)
        {
            return _walletRepository.Get(id);
        }

        public Task<Wallet> Update(Wallet wallet)
        {
            return _walletRepository.Update(wallet);
        }
    }
}
