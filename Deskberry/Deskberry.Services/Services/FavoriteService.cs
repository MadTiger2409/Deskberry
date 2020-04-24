using Deskberry.Services.Interfaces;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.Common.Models;
using Deskberry.CommandValidation.CommandObjects.Favorite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deskberry.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly DeskberryContext _context;

        public FavoriteService(DeskberryContext context)
        {
            _context = context;
        }

        public async Task<Favorite> AddAsync(CreateFavorite command, Account account)
        {
            var favorite = new Favorite(command.Title, command.Uri) { Account = account };
            _context.Favorites.Add(favorite);

            await _context.SaveChangesAsync().ConfigureAwait(true);

            return favorite;
        }

        public async Task DeleteAsync(int id)
        {
            var favorite = await GetAsync(id).ConfigureAwait(true);
            _context.Favorites.Remove(favorite);

            await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task DeletellAsync(Account account)
        {
            _context.Favorites.RemoveRange(account.Favorites);

            await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task<List<Favorite>> GetAllForUserAsync(int userId) => await _context.Favorites.Where(x => x.AccountId == userId).ToListAsync().ConfigureAwait(true);

        public async Task<Favorite> GetAsync(int id) => await _context.Favorites.GetById(id).SingleOrDefaultAsync().ConfigureAwait(true);
    }
}