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
    public class NoteNavigationService : INoteNavigationService
    {
        private string _noteNamespace = "Deskberry.UWP.Views.Notes";

        public void NavigateTo(Type viewType)
        {
            var notesPage = GetNotesPage();
            notesPage.NavigationFrame.Navigate(viewType);
        }

        public void NavigateTo(string viewType)
        {
            var notesPage = GetNotesPage();
            var type = Type.GetType($"{_noteNamespace}.{viewType}");

            notesPage.NavigationFrame.Navigate(type);
        }

        private NotesPage GetNotesPage()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            var desktopPage = rootFrame.Content as DesktopPage;
            var notesPage = desktopPage.NavigationFrame.Content as NotesPage;

            return notesPage;
        }
    }
}
