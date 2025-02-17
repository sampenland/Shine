using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shine.Engine
{
    class Log
    {

        public static void PrintDirLocation()
        {
            Print("Location: " + System.IO.Directory.GetCurrentDirectory());
        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }

        public static void Write(string text)
        {
            Print(text);
        }

        public static void Error(string errText)
        {
            Console.WriteLine(errText);
        }
    }
}
