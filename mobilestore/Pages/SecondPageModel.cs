using Microsoft.AspNetCore.Mvc.RazorPages;

public class SecondPageModel : PageModel
{
    public void OnGet()
    {
        ViewData["title"] = "King qua";
    }

}
