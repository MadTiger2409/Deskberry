﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.UWP.Services.Interfaces;
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
            rootFrame.Navigate(viewType, null, new SuppressNavigationTransitionInfo());
        }

        public void NavigateBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }
    }
}
