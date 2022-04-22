using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cs_ef2.Models
{
    public class ShopContext : DbContext
    {
        private const string ConnectionString = @"
        Data Source=localhost,1433;
        Initial Catalog=Shop;
        User ID=SA;
        Password=516489C@k
        ";
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
            .HasIndex(c => c.CategoryName)
            .IsUnique(true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Tao ket noi toi sql server
            base.OnConfiguring(optionsBuilder);
            // Thiet lap logging
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder
            .UseSqlServer(ConnectionString)
            .UseLoggerFactory(loggerFactory);
        }
        public async Task CreateDatabase()
        {
            string dbName = Database.GetDbConnection().Database;
            bool result = await Database.EnsureCreatedAsync();
            string resultString = result ? "Create Database successfully" : "Create Database failed";
            Console.WriteLine($"Database {dbName} - {resultString}");
        }
        public async Task DropDatabase()
        {
            string dbName = Database.GetDbConnection().Database;
            bool result = await Database.EnsureDeletedAsync();
            string resultString = result ? "Drop Database successfully" : "Drop Database failed";
            Console.WriteLine($"Database {dbName} - {resultString}");
        }
    }
}