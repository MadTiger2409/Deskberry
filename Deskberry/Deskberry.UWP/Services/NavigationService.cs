using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Deskberry.UWP.Services
{
    class NavigationService : INavigationService
    {
        public void NavigateTo(Type viewType)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(viewType, null);
        }

        public void NavigateToSubApp(Type viewType)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;
            desktopPage.NavigationFrame.Navigate(viewType, null, new DrillInNavigationTransitionInfo());
        }

        public void ClearSubAppsWindow()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;
            desktopPage.NavigationFrame.BackStack.Clear();
            desktopPage.NavigationFrame.Content = null;
        }

        public void NavigateBackFromSubApp()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;

            if (desktopPage.NavigationFrame.CanGoBack == true)
            {
                desktopPage.NavigationFrame.GoBack();
            }
            else
            {
                desktopPage.NavigationFrame.Content = null;
            }
        }

        public void NavigateBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }
    }
}
