using Microsoft.EntityFrameworkCore;

namespace cs_ef.Models
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        private const string dbConntection = @"
        Data Source=localhost,1433;
        Initial Catalog=Test;
        User ID=SA;
        Password=516489C@k;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(dbConntection);
        }



    }
}