using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.Security
{
    public class AccountPasswordData
    {
        public byte[] PasswordHash { get; protected set; }
        public byte[] Salt { get; protected set; }

        public AccountPasswordData(byte[] passwordHash, byte[] salt)
        {
            PasswordHash = passwordHash;
            Salt = salt;
        }
    }
}