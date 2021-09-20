using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;

        public TransactionService(ITransactionRepository transactionRepository, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
        }


        public async Task<IEnumerable<Transaction>> List(Guid id)
        {
            var wallet = await _walletRepository.Get(id);
            var list = await _transactionRepository.List();

            var result = new List<Transaction>();

            foreach (var t in list)
            {
                if (t.Wallet == wallet)
                {
                    result.Add(t);
                }
            }

            return result;
        }


        public async Task<Transaction> Recharge(double value, Guid id)
        {
            var wallet = await _walletRepository.Get(id);
            var transaction = new Transaction() 
            { 
              Id = Guid.NewGuid(),
              CreatedAt = new DateTime(),
              Value = value,
              Wallet = wallet
            };            

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance += value;
            await _walletRepository.Update(wallet);

            return entity;
        }


        public async Task<Transaction> Bus(Guid id)
        {
            var wallet = await _walletRepository.Get(id);
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedAt = new DateTime(),
                Value = 5.00,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance -= transaction.Value;
            
            await _walletRepository.Update(wallet);

            return entity;
        }

        public async Task<Transaction> Subway(Guid id)
        {
            var wallet = await _walletRepository.Get(id);
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedAt = new DateTime(),
                Value = 6.00,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance -= transaction.Value;
            
            await _walletRepository.Update(wallet);

            return entity;

        }

        public async Task<Transaction> Train(Guid id)
        {
            var wallet = await _walletRepository.Get(id);
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedAt = new DateTime(),
                Value = 7.00,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance -= transaction.Value;
            
            await _walletRepository.Update(wallet);

            return entity;
            
        }
    }
}
