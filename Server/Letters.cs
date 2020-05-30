using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Server
{
    public class Letters
    {
        public static readonly string pathNew = "../../../booksNew/";
        public static readonly string pathOld = "../../../booksOld/";

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

        public static void ChangeLetters(string file)
        {
            int lettersInitial;

            Stopwatch watch = new Stopwatch();
            StringBuilder textNew = new StringBuilder();

            try
            {
                watch.Start();
                string textOld = File.ReadAllText(pathOld + file + ".txt");

                lettersInitial = textOld.Length;
                for (int i = 0; i < lettersInitial; i++)
                {
                    if (letters.ContainsKey(textOld[i]))
                    {
                        // Альтернативным решенем было бы создание обычной строки и добавление.
                        textNew.Append(letters[textOld[i]]);
                    }
                    else
                    {
                        if (!char.IsLetter(textOld[i]))
                        {
                            // Альтернативным решенем было бы создание обычной строки и добавление.
                            textNew.Append(textOld[i]);
                        }
                    }
                }
                watch.Stop();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Name: " + file + $".txt:\n" +
                    $"\t\tInitial Letters: {lettersInitial} " +
                    $"--> Afterwards Letters: {textNew.ToString().Length}\n" +
                    $"\t\tTime: {watch.Elapsed} ({watch.Elapsed:ss\\.fff} sec)");
                Console.ForegroundColor = ConsoleColor.White;

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
    }
}
