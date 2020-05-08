using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIApp.Entities;

namespace WebAPIApp.Data.Configuration
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("users");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(255);
            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(255);
            builder.Property(e => e.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(10);
            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password_hash")
                .HasMaxLength(255);
            builder.Property(e => e.isActive)
                .IsRequired()
                .HasColumnName("is_active")
                .HasDefaultValue(true);
        }
    }
}