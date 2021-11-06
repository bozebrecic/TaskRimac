using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RimacTask.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace RimacTask
{
    public partial class App
    {
        public static HostBuilder _HostBuilder { get; private set; }
        public static IServiceCollection _ServiceCollection { get; private set; }
        public static IConfiguration _Configuration { get; private set; }
        public static IServiceProvider _ServiceProvider { get; private set; }

        public static void CreateHostBuilder()
        {
            _HostBuilder = Host.CreateDefaultBuilder() as HostBuilder;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            CreateHostBuilder();
            ConfigureAppConfiguration();
            ConfigureServices();
            BuildHostBuilder();


            _ServiceProvider = _ServiceCollection.BuildServiceProvider();
            StartWindow mainPage = _ServiceProvider.GetRequiredService<StartWindow>();
            mainPage.Show();
        }

        public static void ConfigureAppConfiguration()
        {
            _HostBuilder.ConfigureHostConfiguration(
                (config) =>
                {
                    config.AddJsonFile("AppSettings.json");

                    _Configuration = config.Build();
                    SetConfiguration(_Configuration);
                }
            );
        }

        public static void ConfigureServices()
        {
            _HostBuilder.ConfigureServices(
                (hostContext, services) =>
                {
                    _ServiceCollection = services;
                    ConfigureServices(services);
                }
            );
        }

        public static void BuildHostBuilder()
        {
            _HostBuilder
                .UseConsoleLifetime()
                .Build();
        }

        //public static void ConfigureOptionBuilder(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_Configuration.GetConnectionString("BiographicDbConnection"));
        //}

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<StartWindow>();
        }

        private static void SetConfiguration(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
    }
}
