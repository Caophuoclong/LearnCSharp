namespace web.Services
{
    public interface IProductService
    {
        public Product GetProductWithID(string productId);
    }
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class ProductService : IProductService
    {
        public List<Product> products = new List<Product>();
        public ProductService()
        {
            products.AddRange(new Product[] {
                new Product() { ID= "product123", Name= "SPP", Price= 3000 },
                new Product() { ID= "product125", Name= "SPP6", Price= 3399 },
                new Product() { ID= "product126", Name= "SPP5", Price= 4200 },
                new Product() { ID= "product127", Name= "SPP4", Price= 5399 },
                new Product() { ID= "product128", Name= "SPP3", Price= 6000 },
                new Product() { ID= "product129", Name= "SPP2", Price= 3500 },

            });
        }
        public Product GetProductWithID(string productID)
        {
            var qr = from p in products
                     where p.ID == productID
                     select p;
            return qr.FirstOrDefault();
        }
    }
}