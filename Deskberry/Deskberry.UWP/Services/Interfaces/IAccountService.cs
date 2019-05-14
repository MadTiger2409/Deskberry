﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.SQLite.Models;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAsync(int id);
        Task<List<Account>> GetAsync();
        Task<bool> AreCredentialsValidAsync(Account account, string password);
        Task<bool> CanLogInAsync(Account account, string password);
        void LogOut();
    }
}
