using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deskberry.SQLite.Models;

namespace Deskberry.SQLite.Data.Extensions.Queries
{
    public static class AccountQueries
    {
        public static IQueryable<Account> GetById(this IQueryable<Account> value, int id) => value.Where(x => x.Id == id);
    }
}
