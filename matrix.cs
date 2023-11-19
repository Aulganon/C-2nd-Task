using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Graf2
{
    internal class Matrix
    {
        static public string GetPath()
        {
            string path = "C:\\Users\\Alganon\\source\\repos\\graf1\\matrixs";

            Console.WriteLine("Write subpaths");
            string subpaths = Console.ReadLine();
            List<string> line = subpaths
                        .Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

            foreach (string arg in line)
            {
                path += ("\\" + arg);
            }
            path += ".txt";
            return path;
        }

        static public List<List<int>> ExtractFromFile(string path)
        {
            List<List<int>> TempArray = new List<List<int>>();

            if (!File.Exists(path))
            {
                Console.WriteLine("Couldn't find the file at such derectory maybe you should try check file location?");
            }

            using (StreamReader sr = new StreamReader(path))
            {
                bool pass_f = true;
                while (!sr.EndOfStream)
                {
                    if (pass_f)
                    {
                        sr.ReadLine();
                        pass_f = false;
                        continue;
                    }
                    List<int> line = sr.ReadLine()
                        .Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => Convert.ToInt32(s)).ToList();

                    TempArray.Add(line);
                }
            }
            return TempArray;
        }

        
    }
}
