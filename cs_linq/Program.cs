using System;
using System.Collections.Generic;
using System.Linq;

namespace cs_linq
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var brands = new List<Brands>() {
            new Brands{ID = 1, Name = "Công ty AAA"},
            new Brands{ID = 2, Name = "Công ty BBB"},
            new Brands{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
            new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
            new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
            new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
            new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
            new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
            new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
            new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
            // var qr = from p in products
            //          where p.Price == 400
            //          select p;
            // qr.ToList().ForEach((prod) => System.Console.WriteLine(prod));
            // Group product by price
            // var qr = from p in products
            //         orderby p.Price descending
            //         group p by p.Price;
            // foreach (var item in qr)
            // {
            //     Console.WriteLine($"Price: {item.Key}");
            //     item.ToList().ForEach(pro => Console.WriteLine($"{pro}"));
            // }

            var qr = from p in products
                     join b in brands on p.Brand equals b.ID
                     where p.Price >= 300 && p.Price <= 500
                     select new
                     {
                         Ten = p.Name,
                         Gia = p.Price,
                         TenThuongHieu = b.Name
                     };
            qr.ToList().ForEach((prod) => System.Console.WriteLine(prod));


        }
    }
}