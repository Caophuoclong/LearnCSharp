using System;
using MyLib;

// Extension method phai khai bao trong static class va phuoc thuc phai la static

namespace ExtensionMethod
{
    public class Program
    {

        public static void Main(string[] args)
        {
            "Ban khong nen an com".WarningLog();
            "Ban vua nhap sai".ErrorLog();

        }
    }
}