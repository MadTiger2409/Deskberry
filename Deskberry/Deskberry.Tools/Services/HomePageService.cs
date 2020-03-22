using Deskberry.SQLite.Data;
using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.HomePage;
using Deskberry.Tools.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.Tools.Services
{
    public class HomePageService : IHomePageService
    {
        private readonly DeskberryContext _context;

        public HomePageService(DeskberryContext context) => _context = context;

        public async Task AddOrUpdateAsync(int accountId, UpdateHomePage command)
        {
            var homePage = await GetAsync(accountId);

            if (homePage == null)
                homePage = Add(accountId, homePage);

            homePage.Update(command.Uri);

            _context.HomePages.Update(homePage);
            await _context.SaveChangesAsync();
        }

        public async Task<HomePage> GetAsync(int accountId) => await _context.HomePages.Where(x => x.AccountId == accountId).SingleOrDefaultAsync();

        private HomePage Add(int accountId, HomePage homePage)
        {
            homePage = new HomePage
            {
                AccountId = accountId
            };

            _context.HomePages.Add(homePage);
            return homePage;
        }
    }
}