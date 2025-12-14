using System.Globalization;

namespace Struct__ref__out__params
{
    internal class Program
    {
        struct Name {
            public string FirstName;
            public string SecondName;
            public string LastName;
        }
        class Worker
        {
            public Name name { set; get; }
            public int age { set; get; }
            public int salary { set; get; }
            public DateTime date { set; get; }

            

        }
        static void Main(string[] args)
        {
            
        }
    }
}
