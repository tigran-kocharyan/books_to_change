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
            int lettersAfterwards = 0;

            Stopwatch watch = new Stopwatch();
            StringBuilder textNew = new StringBuilder();

            watch.Start();
            string textOld = File.ReadAllText(pathOld + file + ".txt");

            lettersInitial = textOld.Length;
            for (int i = 0; i < lettersInitial; i++)
            {
                if (letters.ContainsKey(textOld[i]))
                {
                    // Альтернативным решенем было бы создание обычной строки и добавление.
                    textNew.Append(letters[textOld[i]]);
                    lettersAfterwards++;
                }
                else
                {
                    if (!char.IsLetter(textOld[i]))
                    {
                        // Альтернативным решенем было бы создание обычной строки и добавление.
                        textNew.Append(letters[textOld[i]]);
                        lettersAfterwards++;
                    }
                }
            }
            watch.Stop();
            Console.WriteLine("Current file: " + file + $".txt:\t" +
                $"Initial Letters: {lettersInitial} --> Afterwards Letters: {lettersAfterwards}\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t\tTime: {watch.Elapsed} ({watch.Elapsed:ss\\.fff} sec)");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
