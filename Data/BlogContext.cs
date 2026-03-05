using Microsoft.EntityFrameworkCore;
using blogsite.Models;

namespace blogsite.Data;

public class BlogContext : DbContext
{
  public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

  public DbSet<Post> Post { get; set; } = default!;

}