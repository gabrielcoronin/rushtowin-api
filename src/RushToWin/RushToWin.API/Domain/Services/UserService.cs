using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using RushToWin.API.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;

        public UserService(IUserRepository userRepository, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _walletRepository = walletRepository;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _userRepository.Get(id);
            var wallet = await _walletRepository.Get(user.WalletId);
            user.Wallet = wallet;

            return user;
        }

        public async Task<User> Insert(User entity)
        {
            var wallet = new Wallet() 
            { 
                Id = Guid.NewGuid(), 
                Balance = 0.0, 
            };

            entity.Wallet = wallet;
            return await _userRepository.Insert(entity);
        }

        public async Task<User> Update(User entity)
        {
            var user = await _userRepository.Get(entity.Id);

            user.FullName = entity.FullName;
            user.CPF = entity.CPF;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.Update(user);
        }
    }
}
