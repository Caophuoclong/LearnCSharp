using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProductPageModel : PageModel
{
    public void OnGet()
    {
        var x = Request.RouteValues["id"];
        ViewData["id"] = x;
    }
}