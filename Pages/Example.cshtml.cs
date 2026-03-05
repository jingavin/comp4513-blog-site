using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace blogsite.Pages;

public class ExampleModel : PageModel
{
  [BindProperty]

  public string Name { get; set; } = "Alice";
  public void OnGet()
  {
    ViewData["date"] = DateTime.Today.ToString("dddd, MM yyyy");
  }

  public IActionResult OnPost()
  {
    OnGet();
    return Page();

  }
}


