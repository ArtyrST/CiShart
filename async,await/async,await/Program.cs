using System.Threading.Tasks;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Async_await
{
    
    class FileReader : IEnumerable
    {
        public string? DirectoryPath { get; }
        private List<string>? array;
        static int countFiles = 0;
        static int countDir = 0;
        static int counterOfFiles = 0;
        static string folderPath = "";
        static List<string> textToAdd;
        public FileReader()
        {
            this.DirectoryPath = null;
            this.array = new List<string>();
            textToAdd = new List<string>();
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
            this.array = new List<string>();
            textToAdd = new List<string>();
        }


        
        async public Task ReadDirectory(string word, string? currentPath = null)
        {
            
            
            string targetPath = currentPath ?? DirectoryPath!;

            
            string[] files = Directory.GetFiles(targetPath);
            await FindWord(word, files);

            
            

            
            string[] directories = Directory.GetDirectories(targetPath);
            foreach (string directory in directories)
            {
                countDir++;
                await ReadDirectory(word, directory);
                
            }
            

            
        }
        
        async public Task FindWord(string word, string[] files)
        {
            
            string pathFile = null;
            int counter = 0;
            foreach (string file in files)
            {
                pathFile = file;
                string fileName = Path.GetFileName(file);
                if (File.Exists(pathFile))
                {
                    countFiles++;
                    Console.WriteLine($"Перевірено файлів: {countFiles}");
                    
                    string content = await File.ReadAllTextAsync(pathFile);
                    string[] words = content.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string text in words)
                    {
                        counter++;
                        if (text == word)
                        {
                            this.array?.Add($"Word was founded in file: {fileName}, directory: {pathFile}, at the number: {counter}");
                            textToAdd.Add($"Word was founded in file: {fileName}, directory: {pathFile}, at the number: {counter}\n");

                        }

                    }
                }

            }
            Console.WriteLine($"Перевірено директорій: {countDir}\n");
            


        }

        public async Task CreateFolderLogs(string folderName)
        {
            string DirectoryPath = @"D:\" + folderName;
            if (Directory.Exists(DirectoryPath))
            {
                Console.WriteLine(@$"Папка для логів вже існує ({DirectoryPath}), переходжу до логування...");
            }
            else
            {
                Console.WriteLine(@$"Створюю директорію AsyncLog, розсташування: {DirectoryPath}");
                Directory.CreateDirectory(DirectoryPath);
                Console.WriteLine(@"Директорію було успішно створено, переходжу до логування...");
                
            }
            folderPath = DirectoryPath;

            
            

        }
        public async Task AppendToFile(string name)
        {
            string path = folderPath + @"\" + name + ".txt";
            if (File.Exists(path))
            {
                Console.WriteLine($@"Файл знайдено!");
                
                    await File.AppendAllLinesAsync(path, textToAdd);
                
                
                Console.WriteLine(@"Дані було записано!");
                
            }
            else
            {
                Console.WriteLine("Файлу немає. Створюємо новий...");
                await File.WriteAllLinesAsync(path, textToAdd);
                Console.WriteLine(@"Дані успішно залоговано!");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this.array ?? new List<string>()).GetEnumerator();
        }

    }
    

    internal class Program
    {
        
        async static Task Menu()
        {
            string @path = null;
            string @word = null;
            string logFileName = "";
            int answer = 0;
            bool check = true;
            while (check)
            {
                Console.WriteLine("----------MENU----------");
                Console.WriteLine("1: Choose a word to find and path \n2: Show\n0: Exit");
                answer = int.Parse(Console.ReadLine());
                switch (answer) {
                    case 1:
                        Console.WriteLine("Type a word to find: ");
                        word = Console.ReadLine();
                        Console.WriteLine("Type a path: ");
                        path = Console.ReadLine();
                        Console.Clear();
                        continue;
                    case 2:
                        await ScanerAndPrint(path, word);
                        
                        continue;
                    
                    case 0:
                        check = false;
                        break;


                
                }
            }
        }
        async static Task ScanerAndPrint(string path, string word)
        {
            string answer = "";
            try
            {
                FileReader fileReader = new FileReader();
                await fileReader.ReadDirectory(word, path);
                foreach (string item in fileReader)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(@"Бажаєте створити папку та файл для логування результату? (+\-)");
                answer = Console.ReadLine();
                if (answer == "+")
                {
                    Console.WriteLine(@"Введіть назву директорії: ");
                    string nameOfDir = Console.ReadLine();
                    await fileReader.CreateFolderLogs(nameOfDir!);
                    Console.WriteLine(@"Введіть назву файлу: ");
                    string nameOfLogFile = Console.ReadLine();
                    await fileReader.AppendToFile(nameOfLogFile!);
                    Console.WriteLine(@"Успішно!");
                }
                else if (answer == "-") 
                {
                    Console.WriteLine(@"Повертаємось до меню");
                
                }
                else
                {
                    Console.WriteLine("Введіть значення!");
                }

            }
            catch (Exception ex){
                Console.WriteLine($@"Проблема: {ex.Message}");
            }
            
            
        }
        
        async static Task Main(string[] args)
        {
            Program myProgram = new Program();
            await Menu();
            //Якшо що, текст я писав в різний час, тому він інколи англійський, інколи український (нейромережі не використовував)
            
            

        }
    }
}