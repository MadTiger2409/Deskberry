using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.SQLite.Models;
using Deskberry.UWP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deskberry.UWP.Services
{
    public class AccountService : IAccountService
    {
        private readonly DeskberryContext _context;

        public AccountService(DeskberryContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountAsync(int id)
            => await _context.Accounts.GetById(id).SingleOrDefaultAsync();

        public async Task<List<Account>> GetAccountsAssync()
            => await _context.Accounts.Include(x => x.Avatar).ToListAsync();
    }
}
