using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public static class Bob
{
    public static bool IsNotIncludeString(string statement)
    {

    }
    public static string Response(string statement)
    {
        if (statement.Trim().Length == 0) return "Fine. Be that way!";

        if (!Regex.IsMatch(statement, @"^[a-zA-Z]+$")) return "Whatever.";

        if (statement.EndsWith("?"))
        {
            if (statement.Trim() == statement.ToUpper())
            {
                return "Calm down, I know what I'm doing!";
            }
            else
            {
                return "Sure.";
            }
        }
        if (statement.Trim() == statement.ToUpper())
        {
            return "Whoa, chill out!";
        }
        return "Whatever.";

    }
}