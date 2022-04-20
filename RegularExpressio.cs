using System;
using System.Text.RegularExpressions;
namespace learncsharp
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RegularExpressio : Attribute

    {
        bool isText = Regex.IsMatch("123", "^[a-zZ-a]$");


    }
}