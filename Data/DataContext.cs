using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPIApp.Data.Configuration;
using WebAPIApp.Entities;

namespace WebAPIApp.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);
            
            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity)
                {
                    var entity = entry.Entity as BaseEntity;
                    entity.UpdatedAt = DateTime.UtcNow;
                    if (entry.State == EntityState.Added)
                        entity.CreatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}