using Deskberry.Tools.CommandObjects.Note;
using Deskberry.Tools.Enums;
using Deskberry.UWP.Dialogs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.Helpers
{
    public static class DialogHelper
    {
        public static ContentDialog GetContentDialog(DialogEnum dialogType, object dialogContent)
        {
            ContentDialog dialog;

            switch (dialogType)
            {
                case DialogEnum.EditNoteDialog:
                    dialog = new EditNoteContentDialog
                    {
                        Height = Window.Current.Bounds.Height,
                        Width = Window.Current.Bounds.Width,
                        DataContext = (UpdateNote)dialogContent
                    };
                    break;

                case DialogEnum.DeleteNoteDialog:
                    dialog = new DeleteNoteContentDialog
                    {
                        DataContext = dialogContent
                    };
                    break;

                default:
                    dialog = new ContentDialog();
                    break;
            }

            return dialog;
        }
    }
}
