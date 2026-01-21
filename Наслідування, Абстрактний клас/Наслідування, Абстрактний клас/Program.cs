

namespace Наслідування__Абстрактний_клас
{

    abstract class MainFigure
    {
        
        public virtual double getArea() => 0;
        
        public virtual double getPerimetr() => 0;
    }

    class Triangle : MainFigure
    {
        private int a;
        private int b;
        private int c;
        public static int count { get; private set; }

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            count++;
        }
        public override double getArea()
        {
            int p = a + b + c;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }
        public override double getPerimetr()
        {
            return a + b + c;
        }
    }
    class Square : MainFigure
    {
        private int a;

        public Square(int a)
        {
            this.a = a;
        }
        public override double getArea()
        {
            return a * a;
        }
        public override double getPerimetr()
        {
            return a * 4;
        }
    }

    class ComplexFigure : MainFigure
    {
        private List<MainFigure> array;

        public ComplexFigure() 
        {
            array = new List<MainFigure>();
        }
        public void ToArray(params MainFigure[] a)
        {
            this.array.AddRange(a);
        }
        public void ToString()
        {
            foreach (var f in array)
            {
                Console.WriteLine(
                    $"{f.GetType().Name}: " +
                    $"Area = {f.getArea()}, " +
                    $"Perimeter = {f.getPerimetr()}"
                );
            }
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            ComplexFigure f = new ComplexFigure();
            f.ToArray(new Square(4), new Square(5));
            f.ToString();
           
        }
    }
}
