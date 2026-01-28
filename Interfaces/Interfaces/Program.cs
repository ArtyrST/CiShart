namespace Interfaces
{
    class Array : IOutput, IMath   {
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
            bool check = false;
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
        }
    }
}
