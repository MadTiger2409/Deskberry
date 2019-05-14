using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface INoteService
    {
        Task AddAsync(CreateNote command, int userId);
        Task<Note> GetAsync(int id);
        Task<List<Note>> GetAllAsync(int userId);
        Task UpdateAsync(UpdateNote command);
        Task DeleteAsync(int id);
    }
}
