namespace learncsharp
{
    public class DataInput : EventArgs
    {
        public int Data { get; set; }
        public DataInput(int _data)
        {
            Data = _data;
        }
    }
    public class UserInput
    {
        public event EventHandler Send;
        public void Input()
        {
            do
            {
                System.Console.WriteLine("Nhap 1 so: ");
                string inp = Console.ReadLine() ?? "0";
                int x = Int32.Parse(inp);
                Send?.Invoke(this, new DataInput(x));
            } while (true);
        }
    }
    public class SquareInput
    {
        public void Sub(UserInput u)
        {
            u.Send += Square;

        }
        public void Square(object sender, EventArgs e)
        {
            DataInput d = (DataInput)e;
            int data = d.Data;
            Console.WriteLine($"Binh phuong cua {data}: {Math.Pow(data, 2)}");

        }
    }
    public class SquareRootInput
    {
        public void Sub(UserInput u)
        {
            u.Send += SquareRoot;
        }
        private void SquareRoot(object sender, EventArgs e)
        {
            DataInput d = (DataInput)e;
            int data = d.Data;
            Console.WriteLine($"Can bac 2 cua {data}: {Math.Sqrt(data)}");

        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            UserInput u = new UserInput();
            SquareInput square = new SquareInput();
            SquareRootInput squareRoot = new SquareRootInput();
            Console.CancelKeyPress += (sender, e) =>
            {
                System.Console.WriteLine("Ban vua thoat chuong trinh!");
            };
            square.Sub(u);
            squareRoot.Sub(u);
            u.Input();


        }
    }
}