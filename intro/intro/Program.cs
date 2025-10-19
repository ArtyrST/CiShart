namespace intro
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //4
            int start, end;
            int fib1 = 0, fib2 = 1;

            Console.Write("Введіть межі1: ");
            start = int.Parse(Console.ReadLine());
            Console.Write("Введіть межі2: ");
            end = int.Parse(Console.ReadLine());
            for (int i = start; fib2 != end && fib2 < end; i++) {
                int temp = fib1;
                fib1 = fib2;
                fib2 = temp + fib2;
                Console.WriteLine($"{fib1}");
            }
            //5
            int a, b;
            Console.WriteLine("Введіть А:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть Б");
            b = int.Parse(Console.ReadLine());
            for (int i = a; i < b; i++) {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            //6Користувач з клавіатури вводить довжину лінії, символ
            //            заповнювач, напрямок лінії(горизонтальна, вертикальна).
            //Програма відображає лінію по заданих параметрах.
            //Наприклад: +++++.
            //Параметри лінії: горизонтальна лінія, довжина дорівнює п'яти, символ заповнювач +.
            int lenth, direction;
            string simv;
            Console.Write(" Введіть довжину");
            lenth = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write(" Введіть напрямок (1. Горизонтально, 2.Вертикально)");
            direction = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введіть символ-заповнювач: ");
            simv = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < lenth; i++) {
                if (direction == 1) {
                    Console.Write(simv);
                }
                else if (direction == 2)
                {
                    Console.WriteLine(simv);
                }
            }
            int test = 155;
            string test1 = "test1";

        }
    }
}
