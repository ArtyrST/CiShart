using System.Runtime.Intrinsics.X86;


namespace delegates
{
    internal class Program
    {
        public delegate bool PrintArrayDelegate(int a);
        public delegate void TimeDel();

        static void PrintElements(int a)
        {
            Console.WriteLine(a);
        }

        static bool EvenEl(int a) {


            return a % 2 == 0;

        }
        static bool OddEl(int a) {
            return a % 2 != 0;
        }
        static void Operation(int[] arr, PrintArrayDelegate pd)
        {
            foreach (int i in arr) {
                if (pd(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void ShowCurrentDate()
        {
            Console.WriteLine(DateTime.Now.ToString("d"));
        }
        static void ShowWeek()
        {
            DateTime now = DateTime.Now;
            DayOfWeek day = now.DayOfWeek;
            Console.WriteLine(day.ToString());
        }
        static float RectangleArea(int a, int b, int c) 
        {
            int p = a + b + c;
            double area = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            return (float)area;
            
        }
        
        
        
        
        static void Main(string[] args)
        {
            int[] arr = [1, 5, 6, 1, 65, 6, 7, 21, 2];
            Operation(arr, OddEl);
            Console.WriteLine("---------------");
            Operation(arr, EvenEl);
            Console.WriteLine("---------------");
            Operation(arr, x => x % 6 == 0);
            Console.WriteLine("---------------");
            //2
            Action ShowDate = () => ShowCurrentDate();
            ShowDate();
            Action ShowTimeCurr = () => Console.WriteLine(DateTime.UtcNow.ToString("T"));
            ShowTimeCurr();
            Action ShowWeekDay = () => ShowWeek();
            ShowWeekDay();
            Func<int, int,int ,float> rectangleArea = (a,b,c) => RectangleArea(a,b,c);
            float recArea = rectangleArea(1,1,1);
            Console.WriteLine(recArea);
            Func<int, int, int> squareArea = (a, b) => a * b;
            int sqArea = squareArea(2,5);   
            Console.WriteLine(sqArea);
            //3
            var rainbow = new[] {
                new { Name = "Red", R = 255, G = 0, B = 0 },
                new { Name = "Orange", R = 255, G = 127, B = 0 },
                new { Name = "Yellow", R = 255, G = 255, B = 0 },
                new { Name = "Green", R = 0, G = 255, B = 0 },
                new { Name = "Blue", R = 0, G = 0, B = 255 },
                new { Name = "Dark blue", R = 75, G = 0, B = 130 },
                new { Name = "Purple", R = 148, G = 0, B = 211 }
            };
            string n = Console.ReadLine();
            Action<string> showRainbowRGB = delegate (string n)
            {
                foreach (var item in rainbow)
                {
                    if (item.Name == n)
                    {
                        Console.WriteLine($"{item.Name} is : {item.R}:{item.G}:{item.B}");
                    }
                }
            };
            showRainbowRGB(n);
            //4
            int min = 10;
            int max = 20;
            Func<int[], int> arrayCounter = arr => {
                int count = 0;
                foreach (var item in arr)
                {
                    if (item <= max && item >= min)
                    {
                        count++;
                    }
                }
                return count;
                
            };
            //5








        }
    }
}
