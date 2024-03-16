using BlogWebProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWebProject.Data
{
    public class BlogieDbContext : DbContext
    {
        public BlogieDbContext(DbContextOptions options) : base(options)
        {

        }

        public BlogieDbContext(string defaultConnectionString)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
