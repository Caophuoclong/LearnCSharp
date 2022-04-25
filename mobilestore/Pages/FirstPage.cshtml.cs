using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModel : PageModel
{
    public int index { get; set; }
    public String Welcome()
    {
        ViewData["title"] = "king";
        return $"Xin chao nguyen van a {index}";
    }
}