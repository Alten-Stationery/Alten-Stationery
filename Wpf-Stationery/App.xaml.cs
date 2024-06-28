using Alten_Stationery;
using DBLayer;
using DBLayer.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.IServices;
using ServiceLayer.Services.Classes;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime;
using System.Text;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }



        protected override void OnStartup(StartupEventArgs startupEventArgs)
        {
            base.OnStartup(startupEventArgs);
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<MainWindow>();
            serviceCollection.AddScoped<OfficeSupplies>();

            serviceCollection.AddScoped<IItemsService, ItemsService>();
            serviceCollection.AddScoped<IAlertsService, AlertsService>();
            serviceCollection.AddScoped<IRefillsService, RefillsService>();
            serviceCollection.AddScoped<IUsersService, UsersService>();

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddDbContext<StationeryContext>(options =>
                                            options.UseSqlServer(
                                                Configuration.GetConnectionString("StationaryDB")));
                                               

            ConfigureServices(serviceCollection);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();            

            mainWindow.Show();
        }


        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(MainWindow));
        }
    }

}
