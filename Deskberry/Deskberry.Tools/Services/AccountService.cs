using System.Collections.Generic;
using System.Threading.Tasks;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.SQLite.Extensions.Security;
using Deskberry.SQLite.Models;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deskberry.Tools.Services
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

        public async Task<bool> AreCredentialsValidAsync(Account account, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return await Task.FromResult(_passwordManager.VerifyPasswordHash(password, account.PasswordHash, account.Salt));
        }

        public async Task<bool> CanLogInAsync(Account account, string password)
        {
            var areValid = await AreCredentialsValidAsync(account, password);
            if (areValid == true)
            {
                Session.Set(account.Id, account.Login);
            }
            return areValid;
        }

        public void LogOut() => Session.Clear();

        public async Task<Account> GetAsync(int id)
            => await _context.Accounts.GetById(id).SingleOrDefaultAsync();

        public async Task<List<Account>> GetAsync()
            => await _context.Accounts.Include(x => x.Avatar).ToListAsync();
    }
}
