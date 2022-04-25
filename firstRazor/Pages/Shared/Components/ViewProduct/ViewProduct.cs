using Microsoft.AspNetCore.Mvc;
using firstRazor.Models;
using firstRazor.Services;

namespace firstRazor.Pages.Shared.Components.ViewProduct
{
    public class ViewProduct : ViewComponent
    {
        public List<Product> Products { get; set; }
        public ViewProduct(ProductServices _products)
        {
            Products = _products.Products;
        }
        public IViewComponentResult Invoke()
        {
            return View<List<Product>>(Products);
        }
    }
}