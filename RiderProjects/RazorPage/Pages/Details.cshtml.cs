#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPage.Models.AppDbContext _context;

        public DetailsModel(RazorPage.Models.AppDbContext context)
        {
            _context = context;
        }

        public Articles Articles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Articles = await _context._Articles.FirstOrDefaultAsync(m => m.ArticleId == id);

            if (Articles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
