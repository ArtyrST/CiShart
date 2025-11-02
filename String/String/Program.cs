using System.Runtime.ExceptionServices;
using System;
using System.Text;

namespace String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //5
            string text = "The morning sun rose gently over the quiet hills, painting the sky with golden light. Birds sang softly, and the world awakened with calm energy, ready for a beautiful day.";
            int count = 1;
            char ans = ' ' ;
            int count_user = 3;




            //for (int i = 0; i < text.Length - 1; i++)
            //{
            //    if (text[i].StartsWith(" "))
            //}
            for (int i = 0; i < text.Length; i++) { 
            if (text[i] == ' ') {  
                    count++;
                    if (count == count_user)
                    {
                        ans = text[i+1];
                        break;
                    }
                }
            }
            //count++;
            
            Console.WriteLine(ans);
            Console.WriteLine("-------------------------------------------------------------------------");
            //6
            int counter = 0;
            string text1 = "JIOdsfjsdofi osd josdfij  psoidfjps9fj ojdfopsjdf    sopidfjsdopfijsdpfoj ps jsdpofjspo ijdspfosdj    spfjsdopfjsdfjsopfisdjfsdofp";
            string[] array_string = text1.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";


            
            foreach (string item in array_string) {
                counter++;
                if (counter < array_string.Length) { result += item + "*"; }
                else { result += item; }
            }
            Console.WriteLine(result);
            //7

            StringBuilder sb = new StringBuilder("");

            string ToAppend = "";
            while (true)
            {
                
                ToAppend = Console.ReadLine();
                if (!ToAppend.Contains("."))
                {
                    sb.Append(ToAppend + " ");
                    ToAppend = "";
                }
                else if (ToAppend.Contains(".")) 
                { 
                    break; 
                }
            }

            Console.WriteLine(sb.ToString());



        }
    }
}
