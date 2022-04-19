// using System.Reflection;
// namespace learncsharp
// {
//     class User
//     {
//         public string Name { get; set; }
//         public int Age { get; set; }
//         public User(string name, int age)
//         {
//             this.Name = name;
//             this.Age = age;
//         }
//     }
//     public class TypeIn
//     {
//         public static void Main(string[] args)
//         {
//             User u = new User("Long", 26);
//             PropertyInfo[] p = u.GetType().GetProperties();
//             foreach (PropertyInfo item in p)

//             {
//                 string name = item.Name;
//                 var value = item.GetValue(u);
//                 Console.WriteLine($"{name}: {value}");

//             }

//         }



//     }
// }