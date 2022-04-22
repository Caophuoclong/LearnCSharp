using cs_ef2.Models;
namespace cs_ef2
{
    public class Program
    {
        public static async Task InsertSampleData()
        {
            ShopContext context = new ShopContext();
            Category c1 = new Category() { CategoryName = "Phone", Description = "San pham dien thoai" };
            Category c2 = new Category() { CategoryName = "Laptop", Description = "San pham laptop" };
            await context.categories.AddRangeAsync(c1, c2);
            List<Product> products = new List<Product>(){
                new Product(){ ProductName = "Iphone 8", Price=1000, Category = c1 },
                new Product(){ ProductName = "MacBook M1", Price=2000, Category = c2 },
                new Product(){ ProductName = "Samsung Note 22", Price=900, Category = c1}
            };
            await context.products.AddRangeAsync(products);
            int rows = await context.SaveChangesAsync();
            Console.WriteLine($"{rows} are inserted to Category");

        }
        public static async void GetProduct(int productId)
        {
            ShopContext dbContext = new ShopContext();
            Product product = (from p in dbContext.products where p.ProductId == productId select p).FirstOrDefault();
            dbContext.Entry(product).Reference(x => x.Category).Load();
            product?.PrintData();
            if (product.Category != null)
            {
                Console.WriteLine($"{product.Category.CategoryName}");
            }
            else
            {
                System.Console.WriteLine("Could not find Category");
            }
        }
        public static void GetProductInCategory(int categoryId)
        {
            ShopContext dbContext = new ShopContext();
            var category = (from c in dbContext.categories where c.CategoryId == categoryId select c).FirstOrDefault();
            var e = dbContext.Entry(category);
            e.Collection(c => c.Products).Load();
            category?.Products.ToList().ForEach(p => p.PrintData());

        }
        public static async Task Main(string[] args)
        {
            ShopContext shopContext = new ShopContext();
            try
            {
                // shopContext.DropDatabase().Wait();
                // shopContext.CreateDatabase().Wait();
                // await InsertSampleData();
                // GetProduct(2);
                GetProductInCategory(1);

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Duplicate value: " + e.Message);
            }

        }
    }
}