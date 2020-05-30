using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.CommandValidation.CommandObjects.Account
{
    public class CreateAccount
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}