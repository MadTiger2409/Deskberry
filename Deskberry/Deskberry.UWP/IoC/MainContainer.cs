using System;
using Deskberry.SQLite.Data;
using Deskberry.UWP.Services;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deskberry.UWP.IoC
{
    public static class MainContainer
    {
        public static IServiceProvider Container { get; private set; }

        public static void RegisterService()
        {
            var services = new ServiceCollection();

            #region Databases
            services.AddDbContext<DeskberryContext>(options => options.UseSqlite(@"Data Source=deskberry.db"));
            #endregion

            #region ViewModels
            services.AddScoped<MainPageViewModel>();
            #endregion

            #region Services
            services.AddScoped<IAccountService, AccountService>();
            #endregion

            Container = services.BuildServiceProvider();
        }
    }
}
