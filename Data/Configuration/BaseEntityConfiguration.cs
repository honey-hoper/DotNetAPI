using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIApp.Entities;

namespace WebAPIApp.Data.Configuration
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(it => it.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(it => it.CreatedAt)
                .HasColumnName("created_at");
        }
    }
}