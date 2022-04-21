using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

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
            using DbCommand command = myDatabase.command();
            // If use this command, it will create a mistake in runtime, because hacker can inject some command into database;
            // command.CommandText = $"SELECT TOP({limit})* FROM SanPham";
            // Instead of using following command:
            command.CommandText = "SELECT TOP(@limit) * FROM SanPham";
            command.Parameters.Add(new SqlParameter("@limit", limit));
            DbDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    products.Add(new Product() { Id = (int)reader["SanPhamId"], Name = (string)reader["TenSanPham"] });
                }
            }
            else
            {
                System.Console.WriteLine("No data");
            }
            myDatabase.Close();
            return products;
        }
        public int CountProduct()
        {
            myDatabase.Open();
            using DbCommand command = myDatabase.command();
            command.CommandText = "SELECT COUNT(*) FROM SanPham";
            // ExecuteScalar() is used to get the first column of the first row of the result set returned by the query.
            /**
                | ID | Ten |
                | 1  | A   |
                | 2  | B   |
            It will return 1
            **/
            // This query consist with commands like count, sum, max, avag,...
            int count = (int)command.ExecuteScalar();
            myDatabase.Close();
            return count;
        }
        public int UpdateName(int productId, string productName)
        {
            myDatabase.Open();
            using DbCommand command = myDatabase.command();
            command.CommandText = "UPDATE SanPham SET TenSanPham = @productName WHERE SanPhamId = @productId";
            command.Parameters.Add(new SqlParameter("@productId", productId));
            command.Parameters.Add(new SqlParameter("@productName", productName));
            // ExecuteNonQuery() is used to execute a Transact-SQL statement against the connection and return the number of rows affected.
            // It  consist with commands like insert, update, delete,...
            // It tell us know how many rows affected
            int result = command.ExecuteNonQuery();
            myDatabase.Close();
            return result;
        }
        public object GetProductInfo(int productId)
        {
            myDatabase.Open();
            using DbCommand command = myDatabase.command();
            command.CommandText = "GetProductInfo";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@id", productId));
            var reader = command.ExecuteReader();
            object result;
            if (reader.Read())
            {
                result = new
                {
                    ProductName = reader["TenSanpham"]
                    // CategoryName = reader["TenDanhmuc"]
                };
                myDatabase.Close();

                return result;
            }
            else
            {
                myDatabase.Close();

                return null;
            }

        }
    }
}