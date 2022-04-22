using System.Globalization;

namespace cs_ef.Utils
{
    public class CustomRandom
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
            int numberOfWord = 3;
            string x;
            string result = new string(
                    Enumerable.Repeat(chars, random.Next(3, length))
                    .Select(s => s[random.Next(s.Length)]).ToArray()
            );
            x = result;
            for (int i = 0; i < random.Next(numberOfWord); i++)
            {
                x += " ";
                x += new string(
                    Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray()
            );
            }

            string s = new CultureInfo("en-US").TextInfo.ToTitleCase(x);
            return s;
        }
        public static int RandomPrice()
        {
            int e = random.Next(100, 999);
            return e * 10;
        }
    }
}