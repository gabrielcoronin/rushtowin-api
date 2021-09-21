using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using RushToWin.API.Domain.Interfaces.Services;
using RushToWin.Domain.Notifications;
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

        public async Task<Notification> Insert(User entity)
        {
            var email = _userRepository.Get(entity.Email);
            if (email != null) return Notification.CreateError(message: "Email já cadastrado.", statusCode: 400);

            entity.Wallet = new Wallet() 
            { 
                Id = Guid.NewGuid(), 
                Balance = 0.0, 
            };        

            var user = await _userRepository.Insert(entity);

            return Notification.CreateSuccess(user, null, 200, "Usuário criado com sucesso");

        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userRepository.Login(email, password);
            user.Wallet = await _walletRepository.Get(user.WalletId);

            return user;
        }

        public async Task<User> Update(User entity)
        {
            var user = await _userRepository.Get(entity.Id);

            user.FullName = entity.FullName;
            user.CPF = entity.CPF;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.UpdatedAt = DateTime.Now;

            return await _userRepository.Update(user);
        }

        public async Task<User> UpdatePassword(Guid id, string password)
        {
            var user = await _userRepository.Get(id);
                        
            user.Password = password;
            user.UpdatedAt = DateTime.Now;

            return await _userRepository.Update(user);
        }
    }
}
