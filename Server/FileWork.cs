using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class FileWork
    {
        public static readonly string pathNew = "../../../bookNew/";
        public void SaveNew(string name, string text) => File.WriteAllText(text, pathNew + name);

        public string ReadBook(string pathOld) => File.ReadAllText(pathOld);
    }
}
