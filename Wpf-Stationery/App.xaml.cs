using Alten_Stationery;
using DBLayer;
using DBLayer.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.ApplicationServices;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;

namespace Wpf_Stationery
{

    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }



        protected override void OnStartup(System.Windows.StartupEventArgs startupEventArgs)
        {
            base.OnStartup(startupEventArgs);
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<MainWindow>();
            serviceCollection.AddScoped<OfficeSupplies>();

            serviceCollection.AddDataProtection();
            serviceCollection.AddLogging();

            serviceCollection.AddScoped<IItemsService, ItemsService>();
            serviceCollection.AddScoped<IAlertsService, AlertsService>();
            serviceCollection.AddScoped<IRefillsService, RefillsService>();
            serviceCollection.AddScoped<IUsersService, UsersService>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddDbContext<StationeryContext>(options =>
                                            options.UseSqlServer(
                                                Configuration.GetConnectionString("StationeryDB")));


            ConfigureServices(serviceCollection);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }


        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(MainWindow));

            serviceCollection.AddIdentity<DBLayer.Models.User, IdentityRole<int>>()
                .AddSignInManager()
                .AddEntityFrameworkStores<StationeryContext>()
                .AddDefaultTokenProviders();

            serviceCollection.AddHttpContextAccessor();
        }
    }

}
