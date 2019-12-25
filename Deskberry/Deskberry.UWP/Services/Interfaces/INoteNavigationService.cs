using System;

namespace Deskberry.UWP.Services.Interfaces
{
    public interface INoteNavigationService
    {
        void NavigateTo(Type viewType);

        void NavigateTo(string viewType);
    }
}