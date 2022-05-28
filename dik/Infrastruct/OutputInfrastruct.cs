using System;
using System.Collections.Generic;
using System.Text;

namespace dik.Infrastruct
{
    class TextInfrastruct
    {
        public static void WriteError(string s) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("     Error:      " + s);
            Console.ResetColor();
        }

        public static void WriteSucess(string s, string type)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     " + type + ":    " + s);
            Console.ResetColor();
        }
    }
}
