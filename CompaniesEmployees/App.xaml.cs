using CE.EFC.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Windows;

namespace CompaniesEmployees
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<ApplicationContext>(options =>
                    {
                        options.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}/CE.db");
                    });

                    services.RegisterInformationData();

                    services.AddSingleton<MainWindow>();

                    _serviceProvider = services.BuildServiceProvider();

                }).Build();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = _serviceProvider.GetService<MainWindow>();

            mainWindow?.Show();
        }
    }
}