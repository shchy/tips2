using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace tips.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Test>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            var config = builder.Build();

            var connection = config.Get<string>("connection");

            optionsBuilder.UseSqlite(connection);
        }
    }
}
