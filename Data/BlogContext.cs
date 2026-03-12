using Microsoft.EntityFrameworkCore;
using blogsite.Models;

namespace blogsite.Data;

public class BlogContext : DbContext
{
  public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

  public DbSet<Post> Posts { get; set; } = default!; // database table
  public DbSet<Author> Authors { get; set; }
  public DbSet<Category> Categories { get; set; }

}