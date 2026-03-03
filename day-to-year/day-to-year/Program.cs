using System.Runtime.Intrinsics.X86;

namespace day_to_year
{
    internal class Program
    {
        static List<float> toYear(int year)
        {
            float _year = year % 365;
            float _month = (year - _year) % 30;
            float day = year - _year - _month;

            List<float> result = new List<float>();
            result.Add(_year);
            result.Add(_month);
            result.Add(day);

            return result;
           

            
        }
        static void Main(string[] args)
        {
            List<float> list = new List<float>();

            list = toYear(1953);
            foreach (float x in list) {
                Console.WriteLine(x);   
            
            }
        }
    }
}
