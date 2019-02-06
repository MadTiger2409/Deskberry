using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.SQLite.Extensions.Security;
using Deskberry.SQLite.Models;
using Deskberry.UWP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deskberry.UWP.Services
{
    public class AccountService : IAccountService
    {
        private readonly DeskberryContext _context;
        private PasswordManager _passwordManager;

        public AccountService(DeskberryContext context)
        {
            _context = context;
            _passwordManager = new PasswordManager();
        }

        public async Task<bool> AreCredentialsValid(Account account, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return await Task.FromResult(_passwordManager.VerifyPasswordHash(password, account.PasswordHash, account.Salt));
        }

        public async Task<Account> GetAccountAsync(int id)
            => await _context.Accounts.GetById(id).SingleOrDefaultAsync();

        public async Task<List<Account>> GetAccountsAssync()
            => await _context.Accounts.Include(x => x.Avatar).ToListAsync();
    }
}
