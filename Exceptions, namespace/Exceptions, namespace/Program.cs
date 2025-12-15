using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Exceptions__namespace
{
    public class CreditCard
    {
        private string number;
        private string userName;
        private string cvc;
        private DateTime dateofend;

        public string Number {
            get => number;
            set
            {
                if (value.Length != 16)
                {
                    throw new Exception("The card number must contain only 16 digits!");
                }
                if (value == null) {
                    throw new Exception("Credit card number mustn't be empty!");
                }
                number = value;
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                if (value.Length == 0)
                {
                    throw new Exception("The user name can't be empty");
                }
                userName = value;

            }

        }

        public DateTime Dateofend
        {
            get => dateofend;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("The date can't be if past");
                }
                dateofend = value;
            }
        }
        public string CVC
        {
            get => cvc;
            set
            {
                if (value.Length != 3) {
                    throw new Exception("The CVC code must contain 3 digits");
                }
            }
        }

        public CreditCard(string number, string username, string cvc, DateTime date)
        {
            Number = number;
            UserName = username;
            CVC = cvc;
            Dateofend = date;
        }
        public void ToString()
        {
            Console.WriteLine($"Number: {number}, User Name: {userName}, CVC: {cvc}, Date of end: {dateofend}");
        }
        
    }
    internal class Program
    {
        static void IntegerList(string x)
        {
            if (x == null || x.Length > 9)
            {
                throw new Exception("the number is too large");
            }
        }

        static int Calc(string expression)
        {
            if (String.IsNullOrEmpty(expression))
            {
                throw new Exception("The expression cant be empty");

            }
            if (expression.StartsWith("*"))
            {
                throw new Exception("The expression cant start with *-operator");
            }
            if (expression.EndsWith("*"))
            {
                throw new Exception("The expression cant end with *-operator");
            }
            
            
            int result = 1;
            string[] parts = expression.Split('*');
            foreach (string value in parts)
            {
                if (!int.TryParse(value, out int number))
                    throw new Exception($"Некоректне число: {value}");
                result *= number;
            }
            return result;
            
        }
        static void Main(string[] args)
        {
            //1
            string x;

            Console.Write("Type a number: ");
            x = Console.ReadLine();
            try
            {
                IntegerList(x);
                int.Parse(x);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                x = null;
            }

            Console.WriteLine(x);
            //2
            try
            {
                CreditCard p = new CreditCard("4441111452526767", "Artyr Stadnik", "451", new DateTime(2027, 12, 22));
                p.ToString();
                CreditCard d = new CreditCard("1111111111111111", "", "4", new DateTime(2027, 12, 22));
                d.ToString();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            //3
            
            string expression;
            int result;
            Console.Write("Type a expression: ");
            try
            {
                expression = Console.ReadLine();
                result = Calc(expression);
                Console.WriteLine($"Result is: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
