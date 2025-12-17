using System;
using System.Threading;

namespace Task_2
{
    internal class Task_2
    {
        static void Main(string[] args)
        {
            int[] arr = new int[50];
            GenerateDigitsToArray(arr);
            //ArrayToString(arr);
            Thread min = StartThread(() =>
            {
                int min = FindMin(arr);
                Console.WriteLine($"Min digit of array is: {min}");
            });
            
            Thread max = StartThread(() =>
            {
                int max = FindMax(arr);
                Console.WriteLine($"Max digit of array is: {max}");

            });
            
            Thread average = StartThread(() =>
            {
                int average = FindAverage(arr);
                Console.WriteLine($"Average digit of array is {average}");
            });
            Thread SaveToFile = StartThread(() =>
            {
                SaveArrayToFile(arr);
                Console.WriteLine("Recording is done!");
            });


            min.Join();
            max.Join();
            average.Join();
            SaveToFile.Join();

            Console.WriteLine("All is done!");
        }
        static void SaveArrayToFile(int[] arr)
        {
            using (StreamWriter writer = new StreamWriter("array.txt"))
            {
                foreach (int i in arr)
                {
                    writer.Write($"| {i} |");
                }
            }
        }
        static void ArrayToString(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"| {i} |");
            }
        }
        static void GenerateDigitsToArray(int[] array)
        {
            Random x = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = x.Next(1, 50);
            }


        }
        static Thread StartThread(Action action)
        {
            Thread x = new Thread(() => action());
            x.Start();
            return x;
        }
        static int FindMin(int[] arr)
        {
            int min = arr[0];
            foreach (int i in arr)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            return min;
        }
        static int FindMax(int[] arr)
        {
            int min = arr[0];
            foreach (int i in arr)
            {
                if (i > min)
                {
                    min = i;
                }
            }
            return min;
        }
        static int FindAverage(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            int res = sum / arr.Length;
            return res;
        }
    }
}