using Deskberry.SQLite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Deskberry.UWP.IoC
{
    public static class MainContainer
    {
        public static IServiceProvider Container { get; private set; }

        public static void RegisterService()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DeskberryContext>(options => options.UseSqlite(@"Data Source=deskberry.db"));

            Container = services.BuildServiceProvider();
        }
    }
}
