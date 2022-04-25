using firstRazor.Models;
namespace firstRazor.Services
{
    public class ProductServices
    {
        public List<Product> Products { get; set; }
        public ProductServices()
        {
            Products = new List<Product>(){
                new Product(){Id=1, Name = "Ps1", Description = "Tah", Price = 3000},
                new Product(){Id=2, Name = "Ps2", Description = "Tah2", Price = 3500},
                new Product(){Id=3, Name = "Ps3", Description = "Tah3", Price = 3700},
                new Product(){Id=4, Name = "Ps4", Description = "Tah4", Price = 3800},
                new Product(){Id=5, Name = "Ps5", Description = "Tah5", Price = 4000},

            };
        }
    }
}