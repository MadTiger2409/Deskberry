﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Deskberry.Security
{
    public class PasswordManager
    {
        public void CalculatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            var hmac512 = new HMACSHA512();
            passwordSalt = hmac512.Key;
            passwordHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public void CalculatePasswordHash(string password, byte[] passwordSalt, out byte[] passwordHash)
        {
            var hmac512 = new HMACSHA512(passwordSalt);
            passwordHash = hmac512.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public AccountPasswordData CalculatePasswordHash(string password)
        {
            CalculatePasswordHash(password, out byte[] passwordSalt, out byte[] passwordHash);

            return new AccountPasswordData(passwordHash, passwordSalt);
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            CalculatePasswordHash(password, passwordSalt, out byte[] computedHash);

            for (int i = 0; i < passwordHash.Length; i++)
                if (computedHash[i] != passwordHash[i]) return false;

            return true;
        }

        internal void CalculatePasswordHash(string newPassword, byte[] passwordHash, out object passHash) => throw new NotImplementedException();
    }
}