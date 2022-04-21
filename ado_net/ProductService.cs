using System.Data.Common;

namespace ado_net
{
    public class ProductService
    {
        public MyDatabase myDatabase;
        public ProductService(MyDatabase database)
        {
            myDatabase = database;
        }
        public List<Product> getProducts(int limit)
        {
            myDatabase.Open();
            DbCommand command = myDatabase.command();
            System.Console.WriteLine(command);
            command.CommandText = $"SELECT TOP({limit})* FROM SanPham";
            DbDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product() { Id = (int)reader["SanPhamId"], Name = (string)reader["TenSanPham"] });
            }
            myDatabase.Close();
            return products;
        }
    }
}