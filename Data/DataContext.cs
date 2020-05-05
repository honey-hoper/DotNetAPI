using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPIApp.Data.Configuration;
using WebAPIApp.Entities;

namespace WebAPIApp.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<User> Users { get; set; }

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(configuration["DatabaseOptions:ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}