using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBlogs.Core.Models;

namespace WebBlogs.Core.DbContext.Configurations
{
    internal class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Content).HasColumnName("Content");
        }
    }
}
