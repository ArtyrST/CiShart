using System.Collections.Specialized;
using System.Text;

namespace C__files_lesson
{
    
    internal class Program
    {
        static void WriteToFile()
        {
            string text = "Some text";
            Stream stream = new FileStream("lorem.txt", FileMode.Create, FileAccess.Write);
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            stream.Write(bytes);

            stream.Close();

        }
        static void Main(string[] args)
        {
            // FileStream
            
            Stream stream = new FileStream("lorem.txt", FileMode.Open, FileAccess.Read);

            byte[] buffer = new byte[stream.Length];

            int l = stream.Read(buffer);

            string text = Encoding.UTF8.GetString(buffer,0,l);
            Console.WriteLine(text);

            stream.Close();
            
        }
    }
}
