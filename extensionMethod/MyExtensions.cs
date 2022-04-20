using System;
namespace MyLib
{
    public static class MyExtensions
    {
        public static void WarningLog(this string x)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine(x);
            Console.ResetColor();
        }
        public static void ErrorLog(this string x)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine(x);
            Console.ResetColor();
        }


    }
}