using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIApp.Models;

namespace WebAPIApp.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(255);
            builder.Property(e => e.isActive).IsRequired().HasDefaultValue(true);
            builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
        }
    }
}