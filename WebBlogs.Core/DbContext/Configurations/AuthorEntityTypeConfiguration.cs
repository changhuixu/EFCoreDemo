using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBlogs.Core.Models;

namespace WebBlogs.Core.DbContext.Configurations
{
    internal class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.AuthorMembership).HasColumnName("AuthorMembership");

            builder.Metadata.FindNavigation(nameof(Author.Blogs)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Blogs).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
