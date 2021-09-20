﻿using Microsoft.EntityFrameworkCore;
using RushToWin.API.Data.Context;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Insert(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

    }
}