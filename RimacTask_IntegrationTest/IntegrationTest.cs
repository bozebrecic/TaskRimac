using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RimacTask.DbContexts;
using RimacTask_WebAPI;
using System;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace RimacTask_IntegrationTest
{
    public class IntegrationTest
    {
        public HttpClient _Client { get; set; }

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var context = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(NetworkNodeDbContext));
                        if (context != null)
                        {
                            services.Remove(context);
                        }

                        services.AddDbContext<NetworkNodeDbContext>(opt => opt.UseInMemoryDatabase(@"TestDB"));
                    }
                    );
                }

                );

            _Client = appFactory.CreateClient();
        }
    }
}
