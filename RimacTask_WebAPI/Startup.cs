using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RimacTask.DataAccessLayer;
using RimacTask.DbContexts;
using RimacTask.Logic;
using RimacTask.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RimacTask_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<NetworkNodeDataDAL>();
            services.AddTransient<NetworkNodeLogic>();
            services.AddTransient<NetworkNodeManager>();

            services.AddDbContext<NetworkNodeDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("NetworkNodesDBConnection")));

            services.AddTransient<MessageLogic>();
            services.AddTransient<MessagesManager>();
            services.AddTransient<MessagesDataDAL>();

            services.AddTransient<SignalLogic>();
            services.AddTransient<SignalManager>();
            services.AddTransient<SignalDataDAL>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
