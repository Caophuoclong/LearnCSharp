using BookCollection.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCollection.Pages;

public class Signin : PageModel
{
    [BindProperty] public User _user { get; set; }

    public void OnGet()
    {
        
    }
}