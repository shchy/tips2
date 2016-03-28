
using System;
using Microsoft.AspNet.Builder;
using Nancy.Owin;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using tips.Models;
using Nancy;
using Microsoft.Extensions.PlatformAbstractions;
using StructureMap;
using Microsoft.AspNet.Hosting;

namespace tips
{
    public class Startup
    {
        private IContainer Container { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            Container = new Container(config => { config.For<IApplicationEnvironment>().Use(appEnv); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
              .AddSqlite()
              .AddDbContext<ModelContext>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseOwin(x => x.UseNancy(config => config.Bootstrapper = new Bootstrapper(Container)));
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }



    public class RootPathProvider : IRootPathProvider
    {
        public RootPathProvider(IApplicationEnvironment environment)
        {
             Environment = environment;
        }

       private IApplicationEnvironment Environment { get; }

       public string GetRootPath()
       {
            return Environment.ApplicationBasePath;
       }
    }

    public class Bootstrapper : DefaultNancyBootstrapper
    {

        private readonly IContainer container;

        public Bootstrapper(IContainer container)
        {
             this.container = container;
        }

        protected override IRootPathProvider RootPathProvider => container.GetInstance<RootPathProvider>();
    }
}
