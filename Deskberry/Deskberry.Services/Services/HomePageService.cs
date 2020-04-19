using Deskberry.Services.Interfaces;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.HomePage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.Services
{
    public class HomePageService : IHomePageService
    {
        private readonly DeskberryContext _context;

        public HomePageService(DeskberryContext context) => _context = context;

        public async Task AddOrUpdateAsync(Account account, UpdateHomePage command)
        {
            var homePage = new HomePage();

            try
            {
                homePage = await GetAsync(account.Id);
            }
            catch (NullReferenceException)
            {
                homePage = Add(account, homePage);
            }

            homePage.Update(command.Uri);

            _context.HomePages.Update(homePage);
            await _context.SaveChangesAsync();
        }

        public async Task<HomePage> GetAsync(int accountId)
        {
            var homePage = await _context.HomePages.Where(x => x.AccountId == accountId).SingleOrDefaultAsync();

            if (homePage == null)
                throw new NullReferenceException();

            return homePage;
        }

        private HomePage Add(Account account, HomePage homePage)
        {
            homePage = new HomePage
            {
                Account = account,
                AccountId = account.Id
            };

            _context.HomePages.Add(homePage);
            _context.SaveChanges();
            return homePage;
        }
    }
}