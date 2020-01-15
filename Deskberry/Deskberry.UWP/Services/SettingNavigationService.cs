using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.Services
{
    public class SettingNavigationService : ISettingNavigationService
    {
        private readonly string _settingsNamespace = "Deskberry.UWP.Views.Settings";

        public void NavigateTo(Type viewType)
        {
            var settingsPage = GetSettingsPage();
            settingsPage.NavigationFrame.Navigate(viewType);
        }

        public void NavigateTo(string viewType)
        {
            var settingsPage = GetSettingsPage();
            var type = Type.GetType($"{_settingsNamespace}.{viewType}");

            settingsPage.NavigationFrame.Navigate(type);
        }

        private SettingsPage GetSettingsPage()
        {
            var rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;
            var settingsPage = desktopPage.NavigationFrame.Content as SettingsPage;

            return settingsPage;
        }
    }
}
