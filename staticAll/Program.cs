namespace StaticAll
{
    public class Vector
    {
        double x, y;
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Info()
        {
            Console.WriteLine($"x = {x}; y ={y}");

        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector operator +(Vector v1, double value)
        {
            return new Vector(v1.x + value, v1.y + value);
        }


        // Indexer, truy cap phan tu trong class bang chi so
        public double this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    default:
                        throw new Exception("Invalid index");
                }

            }
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new Exception("Invalid index");
                }

            }
        }
    }
    public class Program

    {
        public static void Main(string[] args)
        {
            Vector v1 = new Vector(3, 2);
            Vector v2 = new Vector(5, 6);
            Vector v3 = v1 + v2;
            v3.Info();
            v3 = v3 + 10;
            v3.Info();
            v3[0] += 2;
            v3[1] += 3;
            v3.Info();
        }
    }

}