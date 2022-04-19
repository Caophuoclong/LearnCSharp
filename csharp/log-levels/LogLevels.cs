using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Split(":")[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        return logLine.Split(":")[0].Trim().Split("[")[1].Trim().Split("]")[0].Trim().ToLower();
    }

    public static string Reformat(string logLine)
    {
        return Message(logLine) + $" ({LogLevel(logLine)})";
    }
}
