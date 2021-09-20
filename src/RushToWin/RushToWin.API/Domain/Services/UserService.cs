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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Get(Guid id)
        {
            return await _userRepository.Get(id);
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
            user.UpdatedAt = DateTime.Now;

            return await _userRepository.Update(user);
        }
    }
}
