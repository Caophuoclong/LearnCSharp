using Microsoft.EntityFrameworkCore;
namespace mobilestore.Models
{
    public class MobileStoreContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public MobileStoreContext(DbContextOptions<MobileStoreContext> options) : base(options) { }
    }
}