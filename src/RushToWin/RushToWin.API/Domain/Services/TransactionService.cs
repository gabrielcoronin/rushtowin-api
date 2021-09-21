using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using RushToWin.API.Domain.Interfaces.Services;
using RushToWin.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Wallet> Get(Guid id)
        {
           return await _walletRepository.Get(id);
        }

        public async Task<Transaction> GetLastTransaction(Guid id)
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

            return result.OrderByDescending(result => result.CreatedAt).FirstOrDefault();
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
                CreatedAt = DateTime.UtcNow,
                Value = value,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance += value;
            await _walletRepository.Update(wallet);

            return entity;
        }


        public async Task<Notification> Bus(Guid id)
        {
            var wallet = await _walletRepository.Get(id);

            if (wallet.Balance <= 0) return Notification.CreateError(message: "Não há dinheiro suficiente. Faça a recarga e tente novamente.");

            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Value = 5.00,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance -= transaction.Value;

            if (wallet.Balance < 0) return Notification.CreateError(message: "Não há dinheiro suficiente. Faça a recarga e tente novamente.");

            await _walletRepository.Update(wallet);

            return Notification.CreateSuccess(entity, null, 200, "");
        }

        public async Task<Notification> Subway(Guid id)
        {
            var wallet = await _walletRepository.Get(id);

            if (wallet.Balance <= 0) return Notification.CreateError(message: "Não há dinheiro suficiente. Faça a recarga e tente novamente.");

            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Value = 6.00,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance -= transaction.Value;

            if (wallet.Balance < 0) return Notification.CreateError(message: "Não há dinheiro suficiente. Faça a recarga e tente novamente.");

            await _walletRepository.Update(wallet);

            return Notification.CreateSuccess(entity, null, 200, "");

        }

        public async Task<Notification> Train(Guid id)
        {
            var wallet = await _walletRepository.Get(id);

            if (wallet.Balance <= 0) return Notification.CreateError(message: "Não há dinheiro suficiente. Faça a recarga e tente novamente.");

            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Value = 7.00,
                Wallet = wallet
            };

            var entity = await _transactionRepository.Insert(transaction);

            wallet.Balance -= transaction.Value;

            if (wallet.Balance < 0) return Notification.CreateError(message: "Não há dinheiro suficiente. Faça a recarga e tente novamente.");

            await _walletRepository.Update(wallet);

            return Notification.CreateSuccess(entity, null, 200, "");
        }


    }
}
