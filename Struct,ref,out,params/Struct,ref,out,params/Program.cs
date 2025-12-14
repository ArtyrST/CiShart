using System;
using System.Collections.Generic;

namespace WorkerApp
{
    class Worker
    {
        private string name;
        private int age;
        private int salary;
        private DateTime date;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name can't be empty");

                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 18)
                    throw new ArgumentException("Age must be 18 or more");

                age = value;
            }
        }

        public int Salary
        {
            get => salary;
            set
            {
                if (value < 6000)
                    throw new ArgumentException("Minimal salary is 6000");

                salary = value;
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Date can't be in the future");

                if (value.Year < 2000)
                    throw new ArgumentException("Company did not exist at that time");

                date = value;
            }
        }

        public Worker(string name, int age, int salary, DateTime date)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Date = date;
        }
    }

    internal class Program
    {
        static List<Worker> CreateList()
        {
            return new List<Worker>();
        }

        static void AddWorker(List<Worker> workers)
        {
            try
            {
                Console.Write("Type a name: ");
                string name = Console.ReadLine();

                Console.Write("Type an age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                    throw new ArgumentException("Age must be a number");

                Console.Write("Type a salary: ");
                if (!int.TryParse(Console.ReadLine(), out int salary))
                    throw new ArgumentException("Salary must be a number");

                Console.Write("Type a date (dd.MM.yyyy): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    throw new ArgumentException("Wrong date format");

                Worker worker = new Worker(name, age, salary, date);
                workers.Add(worker);

                Console.WriteLine("✅ Worker added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error: " + ex.Message);
            }
        }

        static void ShowWorkers(List<Worker> workers)
        {
            if (workers.Count == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }

            foreach (var w in workers)
            {
                Console.WriteLine(
                    $"Name: {w.Name}, Age: {w.Age}, Salary: {w.Salary}, Date: {w.Date:dd.MM.yyyy}"
                );
            }
        }

        static void Menu()
        {
            Console.WriteLine("\n1 - Add worker");
            Console.WriteLine("2 - Show workers");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose: ");
        }

        static void Main()
        {
            List<Worker> workers = CreateList();

            while (true)
            {
                Menu();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Wrong menu input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddWorker(workers);
                        break;

                    case 2:
                        ShowWorkers(workers);
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }
            }
        }
    }
}
