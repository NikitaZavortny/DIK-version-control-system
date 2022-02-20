using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using dik.models;

namespace dik
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args[0] = "dik-help";
            }
            OperateCommands(args);
        }

        public static void OperateCommands(string[] a)
        {
            switch (a[0])
            {
                case "dik-help":
                    CommandImpl.dikHelp();
                    break;
                case "dik-commit":
                    if (a.Length < 2) 
                    {
                        Console.WriteLine("No path to folder!!!");
                    }
                    if (a.Length < 3) 
                    {
                        Console.WriteLine("No name for commit!!!");
                    }
                    CommandImpl.dikCommit(a[1], a[2]);
                    break;
                case "dik-delete":
                    break;
            }

        }
    }

    class CommandImpl
    {

        public static void dikHelp()
        {
            Console.WriteLine("Welcome to dik - a new version control system :)");
            Console.WriteLine("dik-commit - make commit");
            Console.WriteLine("dik-delete - delete all commits");
        }

        public static void dikCommit(string folderpath, string name)
        {
            List<Element> v = Infrastructure.AllElementsInFolder(folderpath);

            string s = JsonConvert.SerializeObject(v);
            File.WriteAllText(folderpath + @"\" + name + ".dik", s);
            foreach (var f in v)
            {
                Console.WriteLine(f);
            }
        }
    }
}
