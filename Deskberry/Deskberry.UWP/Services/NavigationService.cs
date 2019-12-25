using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Deskberry.UWP.Services
{
    internal class NavigationService : INavigationService
    {
        public void ClearSubAppsWindow()
        {
            var rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;
            desktopPage.NavigationFrame.BackStack.Clear();
            desktopPage.NavigationFrame.Content = null;
        }

        public void NavigateBack()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }

        public void NavigateBackFromSubApp()
        {
            var rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;

            if (desktopPage.NavigationFrame.BackStackDepth > 0)
            {
                desktopPage.NavigationFrame.GoBack();
            }
            else
            {
                desktopPage.NavigationFrame.BackStack.Clear();
                desktopPage.NavigationFrame.Content = null;
            }
        }

        public void NavigateTo(Type viewType)
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(viewType, null);
        }

        public void NavigateToSubApp(Type viewType)
        {
            var rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;
            desktopPage.NavigationFrame.Navigate(viewType, null, new DrillInNavigationTransitionInfo());
        }
    }
}