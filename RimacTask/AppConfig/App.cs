using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using RimacTask.DataAccessLayer;
using RimacTask.DbContexts;
using RimacTask.Logic;
using RimacTask.Manager;
using RimacTask.ViewModels;
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
            StartViewModel startViewModel = _ServiceProvider.GetRequiredService<StartViewModel>();

            StartWindow startWindow = new StartWindow(startViewModel);
            startWindow.Show();
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

        public static void ConfigureOptionBuilder(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_Configuration.GetConnectionString("NetworkNodesDBConnection"));
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

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<StartWindow>();
            services.AddTransient<OpenFileDialog>();
            services.AddTransient<StartViewModel>();
            //services.AddTransient<DAL>();
            services.AddTransient<NetworkNodeDataDAL>();
            services.AddDbContext<NetworkNodeDbContext>(options => { ConfigureOptionBuilder(options); });
            //services.AddTransient<ModelLogic>();
            services.AddTransient<ParseDbcFileLogic>();
            //services.AddTransient<ModelManager>();
            services.AddTransient<NetworkNodeManager>();

        }

        private static void SetConfiguration(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
    }
}
