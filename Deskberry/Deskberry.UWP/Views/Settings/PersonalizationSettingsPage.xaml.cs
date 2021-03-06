﻿using Deskberry.UWP.IoC;
using Deskberry.UWP.ViewModels.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Deskberry.UWP.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonalizationSettingsPage : Page
    {
        public PersonalizationSettingsPage()
        {
            this.InitializeComponent();

            var vm = MainContainer.Container.GetService<PersonalizationSettingsPageViewModel>();
            vm.InitializeDataAsync();
            DataContext = vm;
        }
    }
}