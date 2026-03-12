using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using blogsite.Data;
using blogsite.Models;

namespace blogsite.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly blogsite.Data.BlogContext _context;

        public CreateModel(blogsite.Data.BlogContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Post Post { get; set; } = default!;

        public SelectList AuthorOptions { get; set; }
        public SelectList CategoryOptions { get; set; }

        public IActionResult OnGet()
        {
            AuthorOptions = new SelectList(_context.Authors, "Id", "Name");
            CategoryOptions = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newPost = new Post();

            if (await TryUpdateModelAsync<Post>(
                newPost,
                "post", // prefix
                p => p.Title, p => p.Content, p => p.AuthorId, propertyFilter => propertyFilter.CategoryId
                ))
            {
                _context.Posts.Add(newPost);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            return Page();

        }
    }
}
