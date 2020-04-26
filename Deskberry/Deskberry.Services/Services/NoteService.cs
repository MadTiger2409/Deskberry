using Deskberry.Services.Interfaces;
using Deskberry.SQLite.Data;
using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.Common.Models;
using Deskberry.CommandValidation.CommandObjects.Note;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deskberry.Services
{
    public class NoteService : INoteService
    {
        private readonly DeskberryContext _context;

        public NoteService(DeskberryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CreateNote command, Account account)
        {
            var note = new Note(command.Title, command.Description) { Account = account };
            _context.Notes.Add(note);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var note = await GetAsync(id);
            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Note>> GetAllForUserAsync(int userId) => await _context.Notes.Where(x => x.AccountId == userId).ToListAsync();

        public async Task<Note> GetAsync(int id) => await _context.Notes.GetById(id).SingleOrDefaultAsync();

        public async Task UpdateAsync(UpdateNote command)
        {
            var note = await GetAsync(command.Id);
            note.Update(command.Title, command.Content);

            await _context.SaveChangesAsync();
        }
    }
}