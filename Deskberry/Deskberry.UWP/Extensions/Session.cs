using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.Extensions
{
    public static class Session
    {
        public static int Id { get; set; }
        public static string Login { get; set; }

        public static void Set(int id, string login)
        {
            Id = id;
            Login = login;
        }

        public static void Clear()
        {
            Id = 0;
            Login = null;
        }
    }
}
