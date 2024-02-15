using Microsoft.EntityFrameworkCore;

namespace JsonApiExample.Model
{
    public class JsonApiDbContext : DbContext
    {
        public DbSet<Post> Post => Set<Post>();
        public DbSet<Comment> Comment => Set<Comment>();
        public DbSet<Category> Category => Set<Category>();

        public JsonApiDbContext(DbContextOptions<JsonApiDbContext> options)
            : base(options)
        {
        }
    }
}
