
using System;
using Microsoft.AspNet.Builder;
using Nancy.Owin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using tips2.Models;

namespace tips2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
              .AddSqlite()
              .AddDbContext<ModelContext>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseOwin(x => x.UseNancy());
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
