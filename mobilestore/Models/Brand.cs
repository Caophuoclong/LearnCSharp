using System.ComponentModel.DataAnnotations;

namespace mobilestore.Models
{
    public class Brand
    {
        [Key] public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Product> Products { get; set; }
    }
}