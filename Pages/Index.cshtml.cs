using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using blogsite.Data;
using blogsite.Models;

namespace blogsite.Pages;

public class IndexModel : PageModel
{
    private readonly BlogContext _context;

    public IndexModel(BlogContext context)
    {
        _context = context;
    }

    public List<Post> Posts { get; set; }
    public List<Category> Categories { get; set; }

    public async Task OnGetAsync()
    {
        Posts = await _context.Posts.Include(p => p.Author).Include(p => p.Category).ToListAsync();
        Categories = await _context.Categories.Include(c => c.Posts).ToListAsync();
    }
}
