using System.Threading.Tasks;
using System;
using System.IO;
using System.Diagnostics;

namespace Async_await
{
    class FileReader
    {
        public string? DirectoryPath { get; }
        public FileReader()
        {
            DirectoryPath = null;
        }
        public FileReader(string? DirectoryPath)
        {
            if (string.IsNullOrWhiteSpace(DirectoryPath))
            {
                throw new ArgumentNullException(nameof(DirectoryPath) + " was null, please type a correct path");
            }
            if (!Directory.Exists(DirectoryPath))
            {

                throw new DirectoryNotFoundException(nameof(DirectoryPath) + " was not found, please type a correct path");
            }
            this.DirectoryPath = DirectoryPath;

        }

        public string ReadDirectory(string word, string? currentPath = null)
        {
            
            string targetPath = currentPath ?? DirectoryPath!;

            
            string[] files = Directory.GetFiles(targetPath);
            string result = FindWord(word, files);

            
            if (result != "")
            {
                return result;
            }

            
            string[] directories = Directory.GetDirectories(targetPath);
            foreach (string directory in directories)
            {
                
                string subDirResult = ReadDirectory(word, directory);

                
                if (subDirResult != "The word is not find :(")
                {
                    return subDirResult;
                }
            }

            return "The word is not find :( ";
        }
        public string FindWord(string word, string[] files)
        {
            
            string pathFile = null;
            int counter = 0;
            foreach (string file in files)
            {
                pathFile = file;
                string fileName = Path.GetFileName(file);
                if (File.Exists(pathFile))
                {
                    string content = File.ReadAllText(pathFile);
                    string[] words = content.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string text in words)
                    {
                        counter++;
                        if (text == word)
                        {
                            return $"Word was founded in file: {fileName}, directory: {pathFile}, at the number: {counter}";

                        }

                    }
                }

            }
            return "";
        }
        

    }


    internal class Program
    {

        static void Main(string[] args)
        {
            string path = @"D:\AsyncTestDir";
            FileReader fileReader = new FileReader(path);
            Console.WriteLine(fileReader.ReadDirectory("test", path));


        }
    }
}