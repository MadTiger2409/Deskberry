﻿using System;
using Deskberry.SQLite.Data;
using Deskberry.UWP.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deskberry.UWP.IoC
{
    public static class MainContainer
    {
        public static IServiceProvider Container { get; private set; }

        public static void RegisterService()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DeskberryContext>(options => options.UseSqlite(@"Data Source=deskberry.db"));

            #region ViewModels

            services.AddScoped<MainPageViewModel>();

            #endregion

            Container = services.BuildServiceProvider();
        }
    }
}
