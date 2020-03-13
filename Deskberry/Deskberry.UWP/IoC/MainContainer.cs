using Deskberry.SQLite.Data;
using Deskberry.Tools.Services;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Services;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.ViewModels;
using Deskberry.UWP.ViewModels.Notes;
using Deskberry.UWP.ViewModels.Settings;
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

            services.AddDbContextPool<DeskberryContext>(options => options.UseSqlite(@"Data Source=deskberry.db"), 2);

            services.AddScoped<MainPageViewModel>();
            services.AddScoped<DesktopPageViewModel>();
            services.AddScoped<NotesViewModel>();
            services.AddScoped<AddNotePageViewModel>();
            services.AddScoped<AllNotesPageViewModel>();
            services.AddScoped<CalculatorViewModel>();
            services.AddScoped<BrowserViewModel>();
            services.AddScoped<SettingsViewModel>();
            services.AddScoped<PasswordSettingsPageViewModel>();
            services.AddScoped<PersonalizationSettingsPageViewModel>();
            services.AddScoped<BrowserSettingsPageViewModel>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<INoteNavigationService, NoteNavigationService>();
            services.AddSingleton<ISettingNavigationService, SettingNavigationService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IFavoriteService, FavoriteService>();

            Container = services.BuildServiceProvider();
        }
    }
}