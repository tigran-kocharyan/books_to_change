using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;

namespace Server
{
    public class Letters
    {
        /// <summary>
        /// Сохраняем Пути к папкам с файлами.
        /// </summary>
        public static readonly string pathNew = "NewBooks/";

        /// <summary>
        /// Сохраняем Пути к папкам с файлами.
        /// </summary>
        public static readonly string pathOld = "OldBooks/";

        /// <summary>
        /// Сохраняем Словарь, где ключ - латинский символ, а
        /// значение - соответсвующий ему символ-строка из кириллицы.
        /// </summary>
        static Dictionary<char, string> letters = new Dictionary<char, string>
        {
            ['A'] = "А",
            ['B'] = "Б",
            ['C'] = "Ц",
            ['D'] = "Д",
            ['E'] = "Е",
            ['F'] = "Ф",
            ['G'] = "Г",
            ['H'] = "Х",
            ['I'] = "И",
            ['J'] = "Ж",
            ['K'] = "К",
            ['L'] = "Л",
            ['M'] = "М",
            ['N'] = "Н",
            ['O'] = "О",
            ['P'] = "П",
            ['Q'] = "КУ",
            ['R'] = "Р",
            ['S'] = "С",
            ['T'] = "Т",
            ['U'] = "У",
            ['V'] = "В",
            ['W'] = "У",
            ['X'] = "КС",
            ['Y'] = "Й",
            ['Z'] = "З",
            ['a'] = "а",
            ['b'] = "б",
            ['c'] = "ц",
            ['d'] = "д",
            ['e'] = "е",
            ['f'] = "ф",
            ['g'] = "г",
            ['h'] = "х",
            ['i'] = "и",
            ['j'] = "ж",
            ['k'] = "к",
            ['l'] = "л",
            ['m'] = "м",
            ['n'] = "н",
            ['o'] = "о",
            ['p'] = "п",
            ['q'] = "ку",
            ['r'] = "р",
            ['s'] = "с",
            ['t'] = "т",
            ['u'] = "у",
            ['v'] = "в",
            ['w'] = "у",
            ['x'] = "кс",
            ['y'] = "й",
            ['z'] = "з",
        };

        /// <summary>
        /// Метод для Чтения, Обработки, Сохранения текста из файла 
        /// и вывода времени его обработки.
        /// </summary>
        public static void ChangeLetters(string file)
        {
            /// Инициализируем таймер и StringBuilder.
            Stopwatch watch = new Stopwatch();
            StringBuilder textNew = new StringBuilder();

            /// Ловим исключения работы с фалом.
            try
            {
                /// Запускаем таймер.
                watch.Start();

                /// Считываем текст.
                string textOld = File.ReadAllText(pathOld + file + ".txt");

                /// Считаем изначальное количество символов и обрабатываем каждый файл.
                int lettersInitial = textOld.Length;
                for (int i = 0; i < lettersInitial; i++)
                {
                    /// Если символ есть в виде ключа, 
                    /// то добавляем значение этого ключа в новый текст.
                    if (letters.ContainsKey(textOld[i]))
                    {
                        // Альтернативным решением было бы создание обычной строки и добавление.
                        textNew.Append(letters[textOld[i]]);
                    }
                    else
                    {
                        /// Проверяем на Unicode.
                        if (!char.IsLetter(textOld[i]))
                        {
                            // Альтернативным решением было бы создание обычной строки и добавление.
                            textNew.Append(textOld[i]);
                        }
                    }
                }
                /// Останавливаем таймер и выводим в консоль всю информацию.
                watch.Stop();
                lock (Console.Out)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("File Name: " + file + ".txt" +
                    $"\tLetters: {lettersInitial} --> {textNew.ToString().Length}" +
                    $"\tTime: {watch.Elapsed} ({watch.Elapsed:ss\\.fff} sec)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                /// Сохраняем файл
                File.WriteAllText(pathNew + "new_" + file + ".txt", textNew.ToString());
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No File Like This. Try Again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Info About File. Try Again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (UnauthorizedAccessException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Access. Try Again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (System.Security.SecurityException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restricted. Try Again...");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR:" + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Метод для обработки текста из ответа HttpResponseMessage 
        /// с подсчетом и выводом времени обработки.
        /// </summary>
        public static void ChangeLettersLink(HttpResponseMessage content)
        {
            /// Инициализируем таймер и StringBuilder и ответ HttpResponseMessage.
            Stopwatch watch = new Stopwatch();
            StringBuilder textNew = new StringBuilder();
            string initialText = content.Content.ReadAsStringAsync().Result;

            /// Запускаем таймер.
            watch.Start();
            for (int i = 0; i < initialText.Length; i++)
            {
                /// Если символ есть в виде ключа, 
                /// то добавляем значение этого ключа в новый текст.
                if (letters.ContainsKey(initialText[i]))
                {
                    // Альтернативным решенем было бы создание обычной строки и добавление.
                    textNew.Append(letters[initialText[i]]);
                }
                else
                {
                    /// Проверяем на Unicode.
                    if (!char.IsLetter(initialText[i]))
                    {
                        // Альтернативным решенем было бы создание обычной строки и добавление.
                        textNew.Append(initialText[i]);
                    }
                }
            }
            /// Останавливаем таймер и выводим в консоль всю информацию.
            watch.Stop();
            lock (Console.Out)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("File Name: The Project Gutenberg.txt" +
                $"\tLetters: {initialText.Length} --> {textNew.ToString().Length}" +
                $"\tTime: {watch.Elapsed} ({watch.Elapsed:ss\\.fff} sec)");
                Console.ForegroundColor = ConsoleColor.White;
            }
            /// Сохраняем файл
            File.WriteAllText(pathNew + "new_book_from_web.txt", textNew.ToString());
        }
    }
}
