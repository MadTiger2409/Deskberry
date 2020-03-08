using Deskberry.SQLite.Data;
using Deskberry.SQLite.Models;
using Deskberry.Tools.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.Tools.Services
{
    public class AvatarService : IAvatarService
    {
        private DeskberryContext _context;

        public AvatarService(DeskberryContext context)
        {
            _context = context;
        }

        public async Task<List<Avatar>> GetAsync() => await _context.Avatars.ToListAsync();
    }
}