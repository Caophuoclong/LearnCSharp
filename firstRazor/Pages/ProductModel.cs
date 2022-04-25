using firstRazor.Models;
using firstRazor.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
namespace firstRazor.Pages
{
    public class ProductModel : PageModel
    {
        public List<Product> products { get; set; }
        // public Product product { get; set; } = new Product() { Id = 1, Name = "Ps1", Description = "Tah", Price = 3000 };
        public ProductModel(ProductServices _products, ILogger<ProductModel> logger)
        {
            // products = new List<Product>(){
            //     new Product(){Id=1, Name = "Ps1", Description = "Tah", Price = 3000},
            //     new Product(){Id=2, Name = "Ps2", Description = "Tah2", Price = 3500},
            //     new Product(){Id=3, Name = "Ps3", Description = "Tah3", Price = 3700},
            //     new Product(){Id=4, Name = "Ps4", Description = "Tah4", Price = 3800},
            //     new Product(){Id=5, Name = "Ps5", Description = "Tah5", Price = 4000},
            // };
            products = _products.Products;
            logger.LogInformation("Init productModel");
            // product = new Product() { Id = 1, Name = "Ps1", Description = "Tah", Price = 3000 };
        }

        public Product GetProduct(int id)
        {
            return products.Where(p => p.Id == id).First();
        }
    }
}