using System;
using Deskberry.SQLite.Data;
using Deskberry.Tools.Services;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Services;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.ViewModels;
using Deskberry.UWP.ViewModels.Notes;
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
            services.AddScoped<DesktopPageViewModel>();
            services.AddScoped<NotesViewModel>();
            services.AddScoped<AddNotePageViewModel>();
            services.AddScoped<AllNotesPageViewModel>();
            services.AddScoped<CalculatorViewModel>();
            #endregion

            #region Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddScoped<INoteNavigationService, NoteNavigationService>();
            services.AddScoped<INoteService, NoteService>();
            #endregion

            Container = services.BuildServiceProvider();
        }
    }
}
