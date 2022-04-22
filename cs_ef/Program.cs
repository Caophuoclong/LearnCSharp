using Microsoft.EntityFrameworkCore;
using cs_ef.Models;
using cs_ef.Utils;
using System.Linq;
namespace cs_ef
{
    class Program
    {
        public static async Task CreateDatabase()
        {
            using var dbContext = new ProductDBContext();
            string dbName = dbContext.Database.GetDbConnection().Database;
            bool result = await dbContext.Database.EnsureCreatedAsync();
            string resultString = result ? "Database created" : "Database already exists";
            System.Console.WriteLine($"{dbName} : {resultString}");
        }
        public static async Task DropDatabase()
        {
            using var dbContext = new ProductDBContext();
            string dbName = dbContext.Database.GetDbConnection().Database;
            bool result = await dbContext.Database.EnsureDeletedAsync();
            string resultString = result ? "Database deleted" : "Cannot found database";
            Console.WriteLine($"{dbName} - {resultString}");
        }
        public static async Task InsertProduct(int number)
        {
            using var dbContext = new ProductDBContext();
            for (int i = 0; i < number; i++)
            {
                await dbContext.Products.AddAsync(new Product() { Name = CustomRandom.RandomString(5), Price = CustomRandom.RandomPrice() });
            }
            int rows = await dbContext.SaveChangesAsync();
            Console.WriteLine($"Saved {rows} products!");

        }
        public static async Task RenameProduct(int id, string name)
        {
            using var dbContext = new ProductDBContext();
            Product product = (from p in dbContext.Products.ToList() where p.Id == id select p).FirstOrDefault();
            if (product != null)
            {
                product.Name = name;
                int rows = await dbContext.SaveChangesAsync();
                Console.WriteLine($"Save change {rows} data");
            }

        }
        public static void ReadProducts()
        {
            using var dbContext = new ProductDBContext();
            List<Product> products = dbContext.Products.ToList();
            var qr = from p in products select p;
            Console.WriteLine($"{"Id",3} {"Name",20} {"Price",4}");
            qr.ToList().ForEach(p => PrintData(p));
        }
        public static void GetProduct(int id)
        {
            using var dbContext = new ProductDBContext();
            List<Product> products = dbContext.Products.ToList();
            var qr = from p in products where p.Id == id select p;
            var p1 = qr.FirstOrDefault();
            // System.Console.WriteLine(p1);
            Console.WriteLine($"{"Id",3} {"Name",20} {"Price",4}");
            if (p1 != null)
            {
                PrintData(p1);
            }
        }
        public static void PrintData(Product p)
        {
            Console.WriteLine($"{p.Id,3} {p.Name,20} {p.Price,4}");
        }

        public static void Main(string[] args)
        {
            // CreateDatabase().Wait();
            // DropDatabase().Wait();
            // InsertProduct(3).Wait();
            // ReadProducts().Wait();
            // GetProduct(100);
            RenameProduct(5, "Man").Wait();
        }
    }
}