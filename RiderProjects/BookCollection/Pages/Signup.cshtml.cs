using System.ComponentModel;
using BookCollection.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCollection.Pages;

public class Signup : PageModel
{
    private readonly BookCollectionContext _context;
    [BindProperty] public User _user { get; set; }
    [BindProperty] public Account _account { get; set; }
    [BindProperty]
    [DisplayName("Nhập lại mật khẩu")]
    public string confirmPassword { get; set; }

    public Signup(BookCollectionContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }
    public async Task OnPost()
    {
        _account.salt = "!23123";
        _user.address = "123123123";
        _context._users.Add(_user);
        _context._accounts.Add(_account);
        await _context.SaveChangesAsync();
        if (ModelState.IsValid) {
            // Xử lý, chuyển hướng ...
        }
        else {
        }
    }
}