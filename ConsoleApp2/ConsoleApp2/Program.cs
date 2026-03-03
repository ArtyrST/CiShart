using System.Threading;

namespace ConsoleApp2

{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++) {

                Console.WriteLine("I'm ppidoras blyadskiy " + i);
                Thread.Sleep(500);
                Console.Clear();
            
            }
        }
    }
}
