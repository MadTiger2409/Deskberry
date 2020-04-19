using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Favorite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deskberry.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<Favorite> AddAsync(CreateFavorite command, Account account);

        Task DeleteAsync(int id);

        Task<List<Favorite>> GetAllForUserAsync(int userId);

        Task<Favorite> GetAsync(int id);

        Task DeletellAsync(Account account);
    }
}