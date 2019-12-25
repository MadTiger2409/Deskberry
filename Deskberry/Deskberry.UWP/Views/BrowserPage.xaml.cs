using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace Deskberry.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BrowserPage : Page
    {
        public BrowserPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<BrowserViewModel>();
        }
    }
}
