#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RazorPage.Models;

namespace RazorPage
{
    public class CreateModel : PageModel
    {
        private readonly RazorPage.Models.AppDbContext _context;
        private readonly ILogger<Articles> _logger;

        public CreateModel(ILogger<Articles> logger ,RazorPage.Models.AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Articles Articles { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Articles.ArticleCreatedAt = DateTime.Now;

            _context._Articles.Add(Articles);
            Console.WriteLine(Articles.ArticleCreatedAt);
            var logArticles = JsonConvert.SerializeObject(Articles);
            _logger.LogInformation(logArticles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            // return null;
        }
    }
}
