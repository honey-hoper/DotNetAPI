using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIApp.Entities;

namespace WebAPIApp.Data.Configuration
{
    public class PostConfiguration : BaseEntityConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);
            builder.ToTable("posts");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property("AuthorId")
                .HasColumnName("user_id")
                .IsRequired();
            builder.Property(e => e.Text)
                .IsRequired()
                .HasColumnName("text")
                .HasMaxLength(2000);
            
        }
    }
}