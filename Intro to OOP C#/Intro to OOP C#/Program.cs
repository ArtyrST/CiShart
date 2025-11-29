namespace Intro_to_OOP_C_


{
    public partial class Freezer
    {
        private string brand { get; set; }
        private string model { get; set; }
        private int height { get; set; }
        private int width { get; set; }

        private int lenght { get; set; }

        private int price { get; set; }
        static public int count { get; private set; }

        static public float AveragePrice { get; private set; }

        static private float TotalPrice ;

        static Freezer()
        {
            count = 0;
            AveragePrice = 0;
        }

        public Freezer()
        {
            brand = "unknown";
            price = 0;
        }

        public Freezer(string brand, int price)
        {
            this.brand = brand;
            this.price = price;
            count++;
            TotalPrice += price;
            AveragePrice = TotalPrice / count;
        }

        public Freezer (string model, int height, int width, int length, string brand, int price) : this(brand,price)
        {
            this.model = model;
            this.height = height;
            this.width = width;
            this.lenght = length;
            count++;
            TotalPrice += price;
            AveragePrice = TotalPrice / count;

        }

        



    }



    internal class Program
    {
        static void ArrayFreezer(List<Freezer> array)
        {
            foreach (Freezer freezer in array)
            {
                freezer.ToString();
            }
            return;
        }
        static void Main(string[] args)
        {
            int choose;
            List<Freezer> array = new List<Freezer>();
            while (true) {
                Console.WriteLine("Choose an option: \n1.Add new freezer(default)\n2.Add new freezer(full info)\n3.Show full list of freezers\n0.Exit");
                choose = int.Parse(Console.ReadLine());
                switch (choose) {
                    case 0: break;
                    case 1:
                        Console.Write("Type a brand: ");
                        string brand = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Type a price: ");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Freezer p = new Freezer(brand, price);
                        array.Add(p);
                        continue;
                    case 2:
                        Console.Write("Type a brand: ");
                        brand = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Type a price: ");
                        price = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Type a model: ");
                        string model = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Type a height: ");
                        int height = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Type a width: ");
                        int width = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Type a length: ");
                        int length = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Freezer f = new Freezer(model, height, width, length, brand, price);
                        array.Add(f);
                        continue;
                    case 3:
                        ArrayFreezer(array);
                        Console.WriteLine();
                        continue;
                }
            }

        }
    }
}
