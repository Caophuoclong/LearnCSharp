namespace cs_di
{
    // Class Car dependent in class Horn
    // Implement
    public class Horn
    {
        public void Beep()
        {
            System.Console.WriteLine("Beep...Beep...Beep...Beep...Beep...Beep...Beep...Be!!!");
        }
    }
    // TODO: Method 1
    // Class Car dependent in class horn with new instance Horn
    public class Car1
    {
        public void Beep()
        {
            Horn horn = new Horn();
            horn.Beep();
        }
    }
    // TODO: Method 2
    // In Car, dependency horn is not managed by Car which it passed by constructor or setter or 
    //assign property
    public class Car
    {
        public Horn horn { get; set; }
        public Car(Horn h)
        {
            horn = h;
        }
        public void Beep()
        {
            horn.Beep();
        }
    }
    // TODO: With method 1 when we change class Horn  with **level** as an attribute of the class we must change code in class Car
    // TODO: Other way, with method 2 we dont need to change code of class Car, we only change code when we init Horn instance
    // TODO: With method 2 we also use Denpendency Injection with constructor
    public class Program
    {
        public static void Main(string[] args)
        {
            Horn h = new Horn();
            Car car = new Car(h);
            car.Beep();
        }
    }
}