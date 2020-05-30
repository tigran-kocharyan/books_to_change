using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.IO;

namespace Server
{
    public class Program
    {
        static async Task Main()
        {
            // Название файлов для обработки.
            string[] files = new string[] { "121-0", "1727-0", "4200-0", "58975-0",
                "pg972", "pg3207", "pg19942", "pg27827", "pg43936" };

            // Ссылка на файл в интернете.
            string link = "https://www.gutenberg.org/files/1342/1342-0.txt";

            do
            {
                try
                {
                    SyncMethod(files);
                    await AsyncMethod(files);
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
            Stopwatch stopwatch = new Stopwatch();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sync Method Starts...");
            Console.ForegroundColor = ConsoleColor.White;

            stopwatch.Start();
            foreach (var file in files)
            {
                Letters.ChangeLetters(file);
            }
            stopwatch.Stop();

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
            Stopwatch stopwatch = new Stopwatch();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nAsync Method Starts...");
            Console.ForegroundColor = ConsoleColor.White;

            stopwatch.Start();
            await Task.WhenAll(files.Select(file => Task.Run(() => Letters.ChangeLetters(file))));
            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Async Method Finishes Within: " +
                $"{stopwatch.Elapsed} ({stopwatch.Elapsed:ss\\.fff} sec)\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
