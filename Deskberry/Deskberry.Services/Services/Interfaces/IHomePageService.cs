using Deskberry.Common.Models;
using Deskberry.CommandValidation.CommandObjects.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.Services.Interfaces
{
    public interface IHomePageService
    {
        /// <summary>
        /// Add home page if it doesn't exist. If it does, then update it.
        /// </summary>
        /// <param name="accountId">ID of an account that home page belongs to.</param>
        /// <param name="command">Data about home page for add/update operation.</param>
        /// <returns></returns>
        Task AddOrUpdateAsync(Account account, UpdateHomePage command);

        /// <summary>
        /// Get home page for specyfic account.
        /// </summary>
        /// <param name="accountId">ID of an account that home page belongs to.</param>
        /// <returns></returns>
        Task<HomePage> GetAsync(int accountId);
    }
}