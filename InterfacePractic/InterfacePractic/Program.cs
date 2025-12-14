namespace InterfacePractic
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }
    class Array : IOutput
    {
        public Array()
        {
            array = new List<int>(); 
        }
        public List<int> array {  get; set; }

        public void Add(int value)
        {
            array.Add(value);
        }
        public void Show()
        {
            foreach (var item in array)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Show(string info)
        {
            foreach(var item in array)
            {
                Console.WriteLine($"{item.ToString()} , {info}" );
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array();
            array.Add(15);
            array.Add(16);
            array.Add(17);
            array.Add(18);
            array.Show();
            array.Show("Message");


        }
    }
}
