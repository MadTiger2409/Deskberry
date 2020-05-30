using Deskberry.SQLite.Data;
using Deskberry.Services;
using Deskberry.Services.Interfaces;
using Deskberry.UWP.Services;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.ViewModels;
using Deskberry.UWP.ViewModels.Notes;
using Deskberry.UWP.ViewModels.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.Devices.WiFi;

namespace Deskberry.UWP.IoC
{
    public static class MainContainer
    {
        public static IServiceProvider Container { get; private set; }

        public static void RegisterService()
        {
            var services = new ServiceCollection();

            services.AddDbContextPool<DeskberryContext>(options => options.UseSqlite(@"Data Source=deskberry.db"), 2);

            //! It's experimental
            services.AddSingleton(typeof(WiFiAdapter), WiFiAdapter.FindAllAdaptersAsync().GetAwaiter().GetResult()[0]);

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
            services.AddScoped<NetworkSettingsPageViewModel>();
            services.AddScoped<AccountManagerPageViewModel>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAvatarService, AvatarService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<INoteNavigationService, NoteNavigationService>();
            services.AddSingleton<ISettingNavigationService, SettingNavigationService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddScoped<IWiFiService, WiFiService>();

            Container = services.BuildServiceProvider();
        }
    }
}