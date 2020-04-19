using Deskberry.SQLite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deskberry.Services.Interfaces
{
    public interface IAccountService
    {
        Task UpdatePasswordAsync(Account account, string password);

        Task<bool> AreCredentialsValidAsync(Account account, string password);

        Task<bool> CanLogInAsync(Account account, string password);

        Task<Account> GetAsync(int id);

        Task<List<Account>> GetAsync();

        Task UpdateUserPictureAsync(Account account, Avatar avatar);

        void LogOut();
    }
}