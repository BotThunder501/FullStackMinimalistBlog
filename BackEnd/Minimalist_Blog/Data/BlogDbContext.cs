using Microsoft.EntityFrameworkCore;
using Minimalist_Blog.Models;

namespace Minimalist_Blog.Data
{
    public class BlogDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions and passes it to the base class.
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        // DbSet properties for BlogPost and BlogComment entities.
        public DbSet<BlogPost> BlogPosts { get; set; } = null!;
        public DbSet<BlogComment> BlogComment { get; set; } = null!;

        // Configuring the model using Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostID);

            modelBuilder.Entity<BlogComment>()
                .HasKey(c => c.CommentID);
        }
    }
}
