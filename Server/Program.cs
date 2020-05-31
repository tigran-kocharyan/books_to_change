using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;

namespace Server
{
    public class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <returns></returns>
        static async Task Main()
        {
            // Название файлов для обработки.
            string[] files = new string[] { "121-0", "1727-0", "4200-0", "58975-0",
                "pg972", "pg3207", "pg19942", "pg27827", "pg43936" };

            // Ссылка на файл в интернете.
            string link = "https://www.gutenberg.org/files/1342/1342-0.txt";

            /// Выполняем в цикле запуск
            do
            {
                try
                {
                    /// Запускаем методы синхронные и асинхронные.
                    SyncMethod(files);
                    await AsyncMethod(files);
                    await DownloadMethod(link);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: " + e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\nPress ENTER to continue...");

            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        /// <summary>
        /// Синхронное выполнение чтения, замены и записи.
        /// </summary>
        public static void SyncMethod(string[] files)
        {
            /// Запуск подсчета таймер до и после обработки файлов синхронно.
            Stopwatch stopwatch = new Stopwatch();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Part 1...");
            Console.WriteLine("Sync Method Starts...");
            Console.ForegroundColor = ConsoleColor.White;

            /// Запуск подсчета таймер до и после обработки файлов синхронно.
            stopwatch.Start();
            foreach (var file in files)
            {
                Letters.ChangeLetters(file);
            }
            stopwatch.Stop();

            /// Запуск подсчета таймер до и после обработки файлов синхронно.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sync Method Finishes Within: " +
                $"{stopwatch.Elapsed} ({stopwatch.Elapsed:ss\\.fff} sec)\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Асинхронное выполнение чтения, замены и записи.
        /// </summary>
        public static async Task AsyncMethod(string[] files)
        {
            /// Запуск подсчета таймер до и после обработки файлов асинхронно.
            Stopwatch stopwatch = new Stopwatch();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Part 2...");
            Console.WriteLine("Async Method Starts...");
            Console.ForegroundColor = ConsoleColor.White;

            /// Запуск подсчета таймер до и после обработки файлов асинхронно.
            stopwatch.Start();
            await Task.WhenAll(files.Select(file => Task.Run(() => Letters.ChangeLetters(file))));
            stopwatch.Stop();

            /// Запуск подсчета таймер до и после обработки файлов асинхронно.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Async Method Finishes Within: " +
                $"{stopwatch.Elapsed} ({stopwatch.Elapsed:ss\\.fff} sec)\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static async Task DownloadMethod(string link)
        {
            /// Запуск подсчета таймер до и после обработки текста по ссылке асинхронно.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Part 3...");
            Console.WriteLine("Download Method Starts...");
            Console.ForegroundColor = ConsoleColor.White;

            /// Запуск подсчета таймер до и после обработки текста по ссылке асинхронно.
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage bookText = await client.GetAsync(link))
                {
                    /// Всё тот же алгоритм, что и для обработки обычного текста.
                    if (bookText.IsSuccessStatusCode)
                    {
                        Letters.ChangeLettersLink(bookText);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Link Is Broken. Try Again...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            /// Запуск подсчета таймер до и после обработки текста по ссылке асинхронно.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Download Method Finishes...");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
