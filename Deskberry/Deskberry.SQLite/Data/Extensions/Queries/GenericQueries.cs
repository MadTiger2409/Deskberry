using Deskberry.SQLite.Models.Base;
using System.Linq;

namespace Deskberry.SQLite.Data.Extensions.Queries
{
    public static class GenericQueries
    {
        public static IQueryable<T> GetById<T>(this IQueryable<T> value, int id) where T : ModelBase => value.Where(x => x.Id == id);
    }
}