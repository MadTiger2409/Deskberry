using Deskberry.SQLite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deskberry.Tools.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> AreCredentialsValidAsync(Account account, string password);

        Task<bool> CanLogInAsync(Account account, string password);

        Task<Account> GetAsync(int id);

        Task<List<Account>> GetAsync();

        void LogOut();
    }
}