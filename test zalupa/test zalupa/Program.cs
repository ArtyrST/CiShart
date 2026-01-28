using System.Threading;

namespace test_zalupa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object text = "i am super-puper-duper Gay";
            Thread thread = new Thread(PrintSleep);
            thread.Start(text);
        }
        static void PrintSleep(object obj)
        {
            int st = 10;
            int rad = 10;
            for (int i = 0; i < st; i++) 
            {
                for (int j = 0; j < rad; j++) 
                { 
                if (i == 0 || i == 9)
                    {
                        Console.Write("*");
                        Thread.Sleep(30);
                    }
                
                }
                Console.WriteLine();
            }
        }
    }
}
