using Microsoft.EntityFrameworkCore;
using WebBlogs.Core.DbContext.Configurations;
using WebBlogs.Core.Models;

namespace WebBlogs.Core.DbContext
{
    public class WebBlogsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Author> Authors { get; protected set; }

        public WebBlogsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
        }
    }
}
