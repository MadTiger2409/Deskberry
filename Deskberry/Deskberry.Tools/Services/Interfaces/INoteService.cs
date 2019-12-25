using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Note;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deskberry.Tools.Services.Interfaces
{
    public interface INoteService
    {
        Task AddAsync(CreateNote command, Account account);

        Task DeleteAsync(int id);

        Task<List<Note>> GetAllAsync(int userId);

        Task<Note> GetAsync(int id);

        Task UpdateAsync(UpdateNote command);
    }
}