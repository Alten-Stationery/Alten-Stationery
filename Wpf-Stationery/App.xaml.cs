using Alten_Stationery;
using DBLayer;
using DBLayer.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.ApplicationServices;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Wpf_Stationery
{

    public partial class App : Application
    {
          public static IHost? AppHost { get; private set; }
        public App()
        {
           
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    string connString = hostContext.Configuration.GetConnectionString("StationeryDB");
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<IUnitOfWork,UnitOfWork>();
                    services.AddDbContext<StationeryContext>(options => options.UseSqlServer(connString));

                    services.AddIdentity<DBLayer.Models.User,IdentityRole<int>>()
                        .AddEntityFrameworkStores<StationeryContext>();
                    services.AddTransient<IAlertsService, AlertsService>();
                    services.AddTransient<IItemsService, ItemsService>();
                    services.AddTransient<IRefillsService, RefillsService>();
                    services.AddTransient<IUsersService, UsersService>();
                }).Build();
        }

        protected override async void OnStartup(System.Windows.StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>() ;

            startUpForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost?.StopAsync();
            base.OnExit(e);
        }
    }

}
