using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DesktopPage : Page
    {
        public Frame NavigationFrame
        {
            get { return DesktopFrame; }
            set { DesktopFrame = value; }
        }

        Task DateTimeTask;

        public DesktopPage()
        {
            this.InitializeComponent();
            DataContext = MainContainer.Container.GetService<DesktopPageViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DateTimeTask = UpdateDateAndTimeAsync();
        }

        private async Task UpdateDateAndTimeAsync()
        {
            while (true)
            {
                timeTextBlock.Text = DateTime.Now.ToString("HH:mm");
                dateTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy");
                await Task.Delay(TimeSpan.FromSeconds(0.1));
            }
        }
    }
}
