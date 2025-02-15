using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shine.Engine
{
    class Log
    {
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }

        public static void Error(string errText)
        {
            Console.WriteLine(errText);
        }
    }
}
