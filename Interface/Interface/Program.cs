using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace Interface
{
    interface IWorker
    {
        bool IsWorking { get; }
        void Print();
        // event EventHandler<EventArgs> Working;

    }
    class MyClass
    {

    }
    class MyClass2 : MyClass
    {

    }
    class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public override string ToString() {
            return $"Fullname: {FirstName} {LastName}. " + $"Birthdate: {BirthDate.ToShortDateString()}";
        }
    }
     abstract class Employee : Human
    {
        public string Position { get; set; }
        public double salary { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"Position: {Position}, Salary: {salary}";
        }
    }
    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> ListOfWorker { get; set; } //nullptr
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager
    {
        public List<IWorkable> ListOfWorker { get; set; }

        public void Control()
        {
            Console.WriteLine("I am director! I control all worker");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I count money!!!");
        }

        public void Organize()
        {
            Console.WriteLine("I organize work");
        }
    }
    class Seller : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "I selling products";
        }
    }
    class storkeeper : Employee, IWorkable
    {
        public bool IsWorking =>true;

        public string Work()
        {
            return "Organize product store";
        }
    }
    class Admin : Employee, IManager, IWorkable
    {
        public List<IWorkable> ListOfWorker { get; set; }

        public bool IsWorking => true;

        public void Control()
        {
            Console.WriteLine("I am Admin");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I have much money");
        }

        public void Organize()
        {
            Console.WriteLine("I organize processes");
        }

        public string Work()
        {
            return "Test";
        }
    }


    internal class Program 
    {
        static void Main(string[] args)
        {
            //Director director = new Director()
            IManager director = new Director()
            {
                FirstName = "Artyr",
                LastName = "Stadnik",
                BirthDate =  new DateTime(2006,12,3),
                salary = 1000000000
            };
            IWorkable seller = new Seller()
            {
                FirstName = "Artyrka",
                LastName = "Stadnik",
                BirthDate = new DateTime(2006, 12, 3),
                salary = 1000000000
            };
            Console.WriteLine(seller.Work());

            if (seller is Seller)
            {
                Console.WriteLine($"Seller salary: {(seller as Seller).salary}");
            }

            director.ListOfWorker = new List<IWorkable>
            {
                seller,
                new Seller()
                {
                    FirstName = "Artyrchik",
                    LastName = "Stadnik",
                    BirthDate = new DateTime(2006, 12, 3),
                    salary = 1000000000
                },
                new storkeeper()
                {
                    FirstName = "Arturito",
                    LastName = "Stadnik",
                    BirthDate = new DateTime(2006, 12, 3),
                    salary = 1000000000
                }
            };
            foreach (var item in director.ListOfWorker)
            {
                if (item is Seller)
                {
                    Console.WriteLine((item as Seller)!.Work());
                }
                if (item is storkeeper)
                {
                    Console.WriteLine((item as storkeeper)!.Work());
                }

                Admin admin = new Admin();

                IWorkable worker = admin;
                worker.Work();
                Console.WriteLine(worker.Work());


            }
        }
    }
}
