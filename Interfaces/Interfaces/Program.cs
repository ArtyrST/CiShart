namespace Interfaces
{
    class Array : IOutput, IMath , ISort  {
        private List<int> array;
        public Array(int size)
        {
            array = new List<int>(size);
            Random randomInt = new Random();
            for (int i = 0; i < size - 1; i++) {
                array.Add(randomInt.Next(1,10));
            }
            
        }
        public void Show()
        {
            foreach (var item in array)
            {
                Console.Write($"|{item}| ");
            }
            Console.WriteLine();
        }
        public void Show(string message) 
        {
            Console.WriteLine(message);
        }
        public int Min()
        {
            int min = 0;
            foreach (var item in array)
            {
                if (min < item)
                {
                    min = item;
                
                }

            }
            return min;
        }
        public int Max()
        {
            int max = 0;
            foreach (var item in array)
            {
                if (max > item)
                {
                    max = item;
                }
            }
            return max;
        }
        public float Avg()
        {
            int avg = 0; 
            foreach (var item in array)
            {
                avg += item;
            }
            return avg / array.Count; 
        }
        public bool Search(int valueToSearch)
        {
           
             
            int left = 0;
            int right = array.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == valueToSearch)
                    return true;

                if (array[mid] < valueToSearch)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false;
        }

        public void SortAsc()
        {
            for (int i = 0; i < array.Count; i++) {
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
            
        public void SortDesc()
        {
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        public void SortByParam(bool isAsc) 
        {
            if (isAsc)
            {
                SortAsc();
            }
            else if (!isAsc)
            {
                SortDesc();
            }
        }

    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 test
            Array p = new Array(10);
            p.Show();
            p.Show("test");
            //2 test
            int min = p.Min();
            int max = p.Max();
            float avg = p.Avg();
            bool search = p.Search(4);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(avg);
            Console.WriteLine(search);
            //3 test
            p.SortAsc();
            p.Show();
            p.SortDesc();
            p.Show();
            p.SortByParam(true);
            p.Show();


        }
    }
}
