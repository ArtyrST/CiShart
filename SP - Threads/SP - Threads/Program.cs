using System;
using System.Threading;


namespace SP___Threads
{
    
    
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            int start, end;
            Console.Write("Type a start and end of diapason: ");
            start = int.Parse(Console.ReadLine());
            end = int.Parse(Console.ReadLine());
            int numbers = int.Parse(Console.ReadLine());
            
            //Thread b = new Thread(ShowDigits2);
            //b.Start();
            

            Console.WriteLine("Main is working");
            
            //3
            List<Thread> threads = CreateNewThread(start,end,numbers);
            foreach (Thread thread in threads) {
                thread.Join();
            }



        }

        

        static List<Thread> CreateNewThread(int start, int end, int count)
        {
           List<Thread> threads = new List<Thread>();
            int range = end - start + 1;
            int step = range / count;
            for (int i = 0; i < count; i++)
            {
                int l_start = start + i * step;
                int l_end = (i == count - 1) ? end: l_start + step - 1 ;

                int thread_number = i + 1;

                Thread x = new Thread(() => ShowDigits(new int[] { l_start, l_end, thread_number }));
                threads.Add(x);
                x.Start();

            }

            return threads;
        }
        static void ShowDigits(object obj)
        {
            int[] arr = (int[]) obj;
            int start = arr[0];
            int end = arr[1];
            int numbers = arr[2];
            Console.Write($"Thread number {numbers}");
            for (int i = start; i < end + 1; i++)
            {
                Console.WriteLine($"the digit is: {i}");
                Thread.Sleep(50);
            }
            
        }

        

        
    }
}
