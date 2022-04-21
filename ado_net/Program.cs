using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ado_net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection service = new ServiceCollection();
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                       .AddJsonFile("db_config.json");                  // nạp config định dạng JSON
            IConfigurationRoot config = configBuilder.Build();
            service.AddOptions();
            service.AddSingleton<MyDatabase>();
            service.Configure<Config>(config.GetSection("config"));
            service.AddSingleton<ProductService>();
            ServiceProvider provider = service.BuildServiceProvider();
            ProductService productService = provider.GetService<ProductService>();
            // List<Product> products = productService.getProducts(5);
            // foreach (Product product in products)
            // {
            //     System.Console.WriteLine(product.Id + " " + product.Name);
            // }
            System.Console.WriteLine(productService.GetProductInfo(3));
            // System.Console.WriteLine(productService.CountProduct());
            // System.Console.WriteLine(productService.UpdateName(3, "C#"));

        }
    }
}