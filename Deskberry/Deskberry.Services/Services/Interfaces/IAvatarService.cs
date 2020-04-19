using Deskberry.SQLite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deskberry.Services.Interfaces
{
    public interface IAvatarService
    {
        Task<List<Avatar>> GetAsync();
    }
}