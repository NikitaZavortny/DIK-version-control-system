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
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
