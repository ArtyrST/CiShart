using System.Threading.Tasks;

namespace Tasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1.1
            //Task task = new Task(() =>
            //{
            //    DateTime time = ShowTime();
            //    Console.WriteLine(time);
            //});
            //task.Start();
            //task.Wait();
            ////1.2
            //var task1 = Task.Factory.StartNew(() =>
            //{
            //    DateTime time1 = ShowTime();
            //    Console.WriteLine(time1);
            //});
            //task1.Start();
            //task1.Wait();

            //1.3 (проблема, пише що вже запужений таск)
            //Task.Run(() => {
            //    DateTime time2 = ShowTime();
            //    Console.WriteLine(time2);
            //}).Wait();
            //2
            Console.WriteLine("----------");
            Console.WriteLine("Loading...");
            List<int> ints = new List<int>();
            Task task = new Task(() =>
            {
                for (int i = 2; i < 1001; i++)
                {
                    bool isPrime = true;
                    if (i > 1)
                    {
                        for (int j = 2; j < Math.Sqrt(i); j++)
                        {
                            if (i % j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                    }
                
                    if (isPrime)
                    {
                        ints.Add(i);
                    }
                    //Thread.Sleep(1);
                }
           });
            task.Start();
            task.Wait();
            Console.WriteLine("----------");
            //3
            Task task1 = new Task(() =>
            {
                foreach (int i in ints)
                {
                    Console.WriteLine(i);
                    
                }
            });
            task1.Start();
            task1.Wait();
            //4
            List<int> arrayOfDigit = new List<int>() {1,5,6,1,1,1 };
            Console.WriteLine(arrayOfDigit.Count);
            Task task_min = new Task(() => {
                int min = MinimalDigit(arrayOfDigit);
                Console.WriteLine(min);
                Thread.Sleep(50);
            });
            task_min.Start();
            task_min.Wait();
            Console.WriteLine("Minimal digit task done!");
            Task task_max = new Task(() => {
                int max = MaxDigit(arrayOfDigit);
                Console.WriteLine(max);
                Thread.Sleep(50);
            
            });
            task_max.Start();
            task_max.Wait();
            Console.WriteLine("Maximum digit task done!");
            Task task_ave = new Task(() => {
                int ave = Average(arrayOfDigit);
                Console.WriteLine(ave);
                Thread.Sleep(50);

            });
            task_ave.Start();
            task_ave.Wait();
            Console.WriteLine("Average digit task done!");
            Task task_summ = new Task(() => {
                int summ = Summ(arrayOfDigit);
                Console.WriteLine(summ);
                Thread.Sleep(50);

            });
            task_summ.Start();
            task_summ.Wait();
            Console.WriteLine("Summa digit task done!");
            //5
            Task removeDublicate = Task.Run(() =>
            {
                arrayOfDigit = RemoveDublicate(arrayOfDigit);
                foreach (int digit in arrayOfDigit)
                {
                    Console.Write($"|{digit}| ");
                }
            });

            Task boubleSortTask = removeDublicate.ContinueWith(t =>
            {
                BoubleSort(arrayOfDigit);
            });

            boubleSortTask.Wait();

            Console.Write("Type a digit to find: ");
            int digitToSearch = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Task searchTask = boubleSortTask.ContinueWith(t =>
            {
                int result = BinarySearch(arrayOfDigit, digitToSearch);
                Console.WriteLine($"Result is : {result}");
            });

            searchTask.Wait();



        }

        static int BinarySearch(List<int> arr, int target)
        {
            int left = 0;
            int right = arr.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;

                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
        static void BoubleSort(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                for(int j = 0; j < arr.Count - i - 1; j++)
                {
                    if (arr[i] > arr[j + 1])
                    {
                        int temp = arr[i];
                        arr[i + 1] = arr[j];
                        arr[j + 1] = temp;
                    }
                }
            }
            
        }
        static List<int> RemoveDublicate(List<int> arr) {
            
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    if (arr[i] == arr[j] && i != j)
                    {
                        arr.Remove(arr[i]);
                    }
                }
            }
            return arr;
        }

        static DateTime ShowTime()
        {
            DateTime time = DateTime.Now;
            return time;
        }
        static int Summ(List<int> arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }
        static int Average(List<int> arr)
        {
            int ave = 0;
            foreach (int i in arr)
            {
                ave += i;
            }
            return ave / arr.Count;
        }
        static int MinimalDigit(List<int> arr)
        {
            int min = arr[1];
            foreach(int i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }
        static int MaxDigit(List<int> arr)
        {
            int max = arr[1];
            foreach (int i in arr)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }
    }
}
