using Deskberry.SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deskberry.SQLite.Data.Extensions.Queries
{
    public static class NoteQueries
    {
        public static IQueryable<Note> GetById(this IQueryable<Note> value, int id) => value.Where(x => x.Id == id);
    }
}
