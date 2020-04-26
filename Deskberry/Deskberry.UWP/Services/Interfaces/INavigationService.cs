using System;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface INavigationService
    {
        void ClearSubAppsWindow();

        void NavigateBack();

        void NavigateBackFromSubApp();

        void NavigateTo(Type viewType);

        void NavigateToSubApp(Type viewType);
    }
}