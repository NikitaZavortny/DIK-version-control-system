using System;
using System.Collections.Generic;
using System.Text;

namespace dik.Infrastruct.CommandImplementations
{
    class Help : Command
    {
        public string Name { get; set; } = "help";

        public void Execute(params string[] a)
        {
            Console.WriteLine("Welcome to dik - a new version control system :)");
            Console.WriteLine("newbranch  -<folder path> -<branch name>  - make branch");
            Console.WriteLine("newbranch  -<folder path> -<branch name>  - make branch");
            Console.WriteLine("delete  -<folderpath>                     - delete all .dik files");
            Console.WriteLine("extract  -<file path> -<folder path>      - delete all .dik files");
        }
    }
}
