using Deskberry.SQLite.Data;
using Deskberry.UWP.Views;
using Deskberry.UWP.Views.ViewModels;
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

            #region ViewModels

            services.AddScoped<MainPageViewModel>();

            #endregion

            Container = services.BuildServiceProvider();
        }
    }
}
