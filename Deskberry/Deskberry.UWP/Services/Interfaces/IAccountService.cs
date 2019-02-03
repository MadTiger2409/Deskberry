using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.SQLite.Models;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccountAsync(int id);
        Task<List<Account>> GetAccountsAssync();
        Task<bool> AreCredentialsValid(Account account, string password);
    }
}
