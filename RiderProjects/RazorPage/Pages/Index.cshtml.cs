#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RazorPage.Models;

namespace RazorPage
{
    public class IndexModel : PageModel
    {
        private readonly RazorPage.Models.AppDbContext _context;

        public IndexModel(RazorPage.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Articles> Articles { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            Console.WriteLine(searchString);
            Articles = (from article in _context._Articles.ToList()
                        orderby article.ArticleCreatedAt descending 
                        where article.ArticleContent.Contains(searchString ?? "")
                        select article).ToList();
            if (searchString != null)
                ViewData["count"] = Articles.Count();
        }
    }
}
