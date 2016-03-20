using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace tips2.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "Data Source=test.sqlite";
            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Test>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
