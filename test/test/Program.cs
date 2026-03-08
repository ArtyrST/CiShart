using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileScanner
{
    // 1. Клас для зберігання даних про файл перед сортуванням
    class FileItem
    {
        public string Path { get; set; }
        public long SizeBytes { get; set; }
    }

    // 2. Клас-стан для накопичення списку файлів та помилок
    class ScanState
    {
        public int FileCount { get; set; } = 0;
        public List<FileItem> ScannedFiles { get; set; } = new List<FileItem>();
        public List<string> ErrorLogs { get; set; } = new List<string>();
    }

    class Program
    {
        static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть шлях до директорії для сканування (наприклад, C:\\Users): ");
            string targetDirectory = Console.ReadLine();

            Console.Write("Введіть повний шлях до файлу логів (наприклад, D:\\logs.txt): ");
            string logFilePath = Console.ReadLine();

            if (Directory.Exists(targetDirectory))
            {
                Console.WriteLine("\nПочинаю сканування та збір даних... Це може зайняти час.");
                await ScanSortAndLogAsync(targetDirectory, logFilePath);
                Console.WriteLine($"\n\nСканування та сортування завершено! Логи збережено у: {logFilePath}");
            }
            else
            {
                Console.WriteLine("Вказана директорія не існує. Перевірте правильність шляху.");
            }
        }

        static async Task ScanSortAndLogAsync(string rootPath, string logPath)
        {
            ScanState state = new ScanState();

            // Етап 1: Збираємо всі файли в пам'ять
            await ProcessDirectoryAsync(rootPath, state);

            Console.WriteLine("\nСортування файлів за розміром...");

            // Етап 2: Сортуємо список від найбільшого до найменшого
            var sortedFiles = state.ScannedFiles.OrderByDescending(f => f.SizeBytes).ToList();

            Console.WriteLine("Запис результатів у файл...");

            // Етап 3: Записуємо відсортовані дані у файл
            using (StreamWriter writer = new StreamWriter(logPath, false, System.Text.Encoding.UTF8))
            {
                await writer.WriteLineAsync("--- Звіт про сканування файлів (Відсортовано за розміром) ---");
                await writer.WriteLineAsync($"Директорія: {rootPath}");
                await writer.WriteLineAsync($"Час: {DateTime.Now}\n");

                foreach (var file in sortedFiles)
                {
                    double sizeMb = file.SizeBytes / 1048576.0; // Конвертація в МБ
                    await writer.WriteLineAsync($"[{sizeMb:F2} МБ] {file.Path}");
                }

                // Виводимо всі помилки доступу окремим блоком у кінці файлу
                if (state.ErrorLogs.Count > 0)
                {
                    await writer.WriteLineAsync("\n--- Помилки доступу під час сканування ---");
                    foreach (var error in state.ErrorLogs)
                    {
                        await writer.WriteLineAsync(error);
                    }
                }

                await writer.WriteLineAsync($"\n--- Кінець звіту ---");
                await writer.WriteLineAsync($"Загалом знайдено файлів: {state.FileCount}");
            }
        }

        static async Task ProcessDirectoryAsync(string targetDirectory, ScanState state)
        {
            try
            {
                foreach (string filePath in Directory.EnumerateFiles(targetDirectory))
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(filePath);

                        // Додаємо файл до списку замість миттєвого запису у файл
                        state.ScannedFiles.Add(new FileItem
                        {
                            Path = filePath,
                            SizeBytes = fileInfo.Length
                        });

                        state.FileCount++;

                        // Оновлюємо консоль рідше (кожні 500 файлів), бо збір у пам'ять відбувається швидше
                        if (state.FileCount % 500 == 0)
                        {
                            Console.Write($"\rЗнайдено файлів: {state.FileCount}...");
                        }
                    }
                    catch (Exception ex)
                    {
                        state.ErrorLogs.Add($"[ПОМИЛКА ФАЙЛУ] {filePath} - {ex.Message}");
                    }
                }

                foreach (string subdirectory in Directory.EnumerateDirectories(targetDirectory))
                {
                    await ProcessDirectoryAsync(subdirectory, state);
                }
            }
            catch (UnauthorizedAccessException)
            {
                state.ErrorLogs.Add($"[ВІДМОВЛЕНО В ДОСТУПІ] {targetDirectory}");
            }
            catch (Exception ex)
            {
                state.ErrorLogs.Add($"[ПОМИЛКА ПАПКИ] {targetDirectory} - {ex.Message}");
            }
        }
    }
}