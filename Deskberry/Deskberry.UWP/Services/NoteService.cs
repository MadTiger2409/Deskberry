using Deskberry.SQLite.Data;
using Deskberry.SQLite.Models;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.Tools.CommandObjects.Note;
using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Deskberry.Tools.Services
{
    public class NoteService : INoteService
    {
        private readonly DeskberryContext _context;

        public NoteService(DeskberryContext context)
        {
            _context = context;
        }

        public Task AddAsync(CreateNote command, int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Note>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Note> GetAsync(int id)
        {
            return await _context.Notes.GetById(id).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(UpdateNote command)
        {
            throw new NotImplementedException();
        }
    }
}
