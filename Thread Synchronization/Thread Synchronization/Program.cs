using System.Threading;
using System.Xml;
namespace Thread_Synchronization

{
    class Saver
    {
        private static int _words;
        private static int _lines;
        private static int _punc;

        public static int words => _words;
        public static int lines => _lines;
        public static int? punc => _punc;
        public static void AddWords(int value)
        => Interlocked.Add(ref _words, value);
        public static void AddLines(int value)
        => Interlocked.Add(ref _lines, value);
        public static void AddPunc(int value)
            => Interlocked.Add(ref _punc, value);





    }
    internal class Program
    {
        static readonly char[] PunctuationMarks =
        {
            '.', ',', ';', ':', '–', '—', '‒', '…', '!', '?',
            '"', '\'', '«', '»',
            '(', ')', '{', '}', '[', ']', '<', '>', '/'
        };
        static void Main(string[] args)
        {
            object file_text = File.ReadAllText("data.txt");
            //words
            Thread Words = new Thread(new ParameterizedThreadStart(CountWords));
            Words.Start(file_text);
            //lines
            Thread Lines = new Thread(new ParameterizedThreadStart(CountLines));
            Lines.Start(file_text);
            //Punc
            Thread Punc = new Thread(new ParameterizedThreadStart(CountPunc));
            Punc.Start(file_text);
            //joins
            Words.Join();
            Lines.Join();
            Punc.Join();
            //check
            Console.WriteLine($"Words: {Saver.words}, lines: {Saver.lines}, punc: {Saver.punc}");
        }
        
        static void CountWords(object obj)
        {
            int count = 0;
            string file_text = (string)obj;

            string[] words = file_text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            count = words.Length;
            Saver.AddWords(count);
            
        }
        static void CountLines(object obj) {

            string file_text = (string)obj;
            foreach(var i in file_text)
            {
                if(i == '\n')
                {
                    Saver.AddLines(1);
                }
            }
        }
        static void CountPunc(object obj)
        {
            int count = 0;
            string file_text = (string)obj;
            foreach (var i in file_text)
            {
                if (PunctuationMarks.Contains(i))
                {
                    count++;
                }
            }
            Saver.AddPunc(count);
            
            
            
        }
        

    }
}
