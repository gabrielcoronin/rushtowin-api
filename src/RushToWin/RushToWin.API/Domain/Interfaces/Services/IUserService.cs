using RushToWin.API.Domain.Entities;
using RushToWin.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Notification> Insert(User entity);
        Task<User> Get(Guid id);
        Task<User> Login(string email, string password);
        Task<User> Update(User entity);
    }
}
