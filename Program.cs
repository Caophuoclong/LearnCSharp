namespace learncsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserInput u = new UserInput();
            SubscriberA a = new SubscriberA();
            a.Sub(u);
        }


    }
}