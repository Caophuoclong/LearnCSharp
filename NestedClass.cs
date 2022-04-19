namespace learncsharp;

class NestedClass
{
    private static string x = "";

    public NestedClass(string x1)
    {
        x = x1;
    }
    public class InnerClass
    {
        public void Print()
        {
            Console.WriteLine(x);
        }
    }
}