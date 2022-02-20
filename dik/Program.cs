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
                case "help":
                    CommandImpl.dikHelp();
                    break;
                case "commit":
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
                case "delete":
                    break;
            }

        }
    }

    class CommandImpl
    {

        public static void dikHelp()
        {
            Console.WriteLine("Welcome to dik - a new version control system :)");
            Console.WriteLine("commit  -<folder path> -<commit name>  - make commit");
            Console.WriteLine("delete  -<folderpath>                  - delete all .dik files");
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

        //public static void DikDelete(string folderpath) 
        //{
        //    foreach (var i in Infrastructure.AllFiles(folderpath))
        //    {
        //        if
        //        foreach (var s in Directory.GetDirectories(folderpath))
        //        {
        //            foreach (var d in Infrastructure.AllElementsInFolder(s))
        //            {
        //                elements.Add(d);
        //            }
        //        }
        //    }
        //}
    }
}
