using Microsoft.EntityFrameworkCore;
using Blog.Entity;
using System.Reflection;

namespace Blog.Context
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Post { get; set; }

        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }
    }
}
