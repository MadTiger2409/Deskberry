using Deskberry.CommandValidation.CommandObjects.Note;
using Deskberry.Tools.Enums;
using Deskberry.UWP.Dialogs;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.Helpers
{
    public static class DialogHelper
    {
        public static ContentDialog GetContentDialog(DialogEnum dialogType, object dialogContent = default)
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

                case DialogEnum.DeleteFavoriteDialog:
                    dialog = new DeleteFavoriteContentDialog
                    {
                        DataContext = dialogContent
                    };
                    break;

                case DialogEnum.ConnectNetworkDialog:
                    dialog = new ConnectNetworkDialog();
                    break;

                default:
                    var content = (string)dialogContent;
                    dialog = new StandardDialog(content);
                    break;
            }

            return dialog;
        }
    }
}