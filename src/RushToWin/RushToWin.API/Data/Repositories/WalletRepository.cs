using Microsoft.EntityFrameworkCore;
using RushToWin.API.Data.Context;
using RushToWin.API.Domain.Entities;
using RushToWin.API.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace RushToWin.API.Data.Repositories
{
    public class WalletRepository : IWalletRepository
    {

        private readonly MyDbContext _context;

        public WalletRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> Insert(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public async Task<Wallet> Get(Guid id)
        {
            var wallet = await _context.Wallets.FindAsync(id);

            return wallet;
        }

        public async Task<Wallet> Update(Wallet wallet)
        {

            _context.Entry(wallet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return wallet;

        }
    }
}
