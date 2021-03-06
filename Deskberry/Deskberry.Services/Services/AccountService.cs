﻿using Deskberry.Services.Interfaces;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.Security;
using Deskberry.Common.Models;
using Deskberry.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Deskberry.CommandValidation.CommandObjects.Account;
using System;
using System.Linq;

namespace Deskberry.Services
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

        public async Task AddAccountAsync(CreateAccount command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            if (string.IsNullOrEmpty(command.Password) || string.IsNullOrEmpty(command.Login))
            {
                command.Login = "User";
                command.Password = "User";
            }

            byte[] passwordSalt, passwordHash;

            var avatar = await _context.Avatars.FirstOrDefaultAsync();
            _passwordManager.CalculatePasswordHash(command.Password, out passwordSalt, out passwordHash);

            var account = new Account(command.Login, passwordHash, passwordSalt, avatar);

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
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
                Session.Set(account.Id, account.Login);

            return areValid;
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await GetAsync(id);
            account.Delete();

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetAsync(int id) => await _context.Accounts.GetById(id).SingleOrDefaultAsync();

        public async Task<List<Account>> GetAsync() => await _context.Accounts.Where(x => x.IsActive == true).Include(x => x.Avatar).ToListAsync();

        public void LogOut() => Session.Clear();

        public async Task UpdatePasswordAsync(Account account, string password)
        {
            account.UpdatePassword(password);

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserPictureAsync(Account account, Avatar avatar)
        {
            account.Avatar = avatar;
            account.AvatarId = avatar.Id;

            _context.Avatars.Update(avatar);
            await _context.SaveChangesAsync();
        }
    }
}