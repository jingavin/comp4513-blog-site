using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blogsite.Data;
using blogsite.Models;

namespace blogsite.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly blogsite.Data.BlogContext _context;

        public DetailsModel(blogsite.Data.BlogContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;
        public List<Post> RelatedPosts { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.Author).Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (post is not null)
            {
                Post = post;
                RelatedPosts = await _context.Posts
                    .Where(p => p.CategoryId == post.CategoryId && p.Id != post.Id)
                    .ToListAsync();

                return Page();
            }

            return NotFound();
        }
    }
}
