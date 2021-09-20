using RushToWin.API.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Insert(User entity);
        Task<User> Get(Guid id);
        Task<User> Update(User entity);
    }
}
