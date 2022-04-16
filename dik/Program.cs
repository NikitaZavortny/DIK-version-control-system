using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using dik.models;
using System.Text;
using Newtonsoft.Json.Linq;

namespace dik
{
    class Program
    {
        static void Main(string[] args)
        {
            OperateCommands(new string[]{ "get-branches", @"D:\Новая_папка"});
            //if (args.Length == 0)
            //{
            //    args[0] = "dik-help";
            //}
            //OperateCommands(args);
        }

        public static void OperateCommands(string[] a)
        {
            switch (a[0])
            {
                case "help":
                    CommandImpl.dikHelp();
                    break;

                case "newbranch":
                    if (a.Length < 2) 
                    {
                        Console.WriteLine("No path to folder!!!");
                    }
                    if (a.Length < 3) 
                    {
                        Console.WriteLine("No name for branch!!!");
                    }
                    CommandImpl.dikbranch(a[1], a[2]);
                    break;

                case "init":
                    if (a.Length < 2) 
                    {
                        Console.WriteLine("No path to folder!!!");
                    }
                    Directory.CreateDirectory(a[1]+@"\.dik");
                    break;

                case "delete":
                    if (a.Length < 2)
                    {
                        Console.WriteLine("No path to folder!!!");
                    }
                    CommandImpl.DikDelete(a[1]);
                    break;
                case "get-branches":
                    if (a.Length < 1)
                    {
                        Console.WriteLine("No path to folder!!!");
                    }
                    CommandImpl.GetBranches(a[1]);
                    break;

                //case "extract":
                //    if (a.Length < 2) 
                //    {
                //        Console.WriteLine("No path to file!!!");
                //    }
                //    if (a.Length < 3) 
                //    {
                //        Console.WriteLine("No path to folder of extraction!!!");
                //    }
                //    CommandImpl.Extract(a[1], a[2]);
                //    break;
                case "getbranches":
                    break;
                default:
                    Console.WriteLine("cum");
                    break;
            }

        }
    }

    class CommandImpl
    {

        public static void dikHelp()
        {
            Console.WriteLine("Welcome to dik - a new version control system :)");
            Console.WriteLine("newbranch  -<folder path> -<branch name>  - make branch");
            Console.WriteLine("newbranch  -<folder path> -<branch name>  - make branch");
            Console.WriteLine("delete  -<folderpath>                     - delete all .dik files");
            Console.WriteLine("extract  -<file path> -<folder path>      - delete all .dik files");
        }

        public static void dikbranch(string folderpath, string name)
        {
            if (!Directory.Exists(folderpath + @"\.dik")) 
            {
                Console.WriteLine("Project not initialised!!!");
                return;
            }

            List<Element> v = Infrastructure.AllElementsInFolder(folderpath, true);

            foreach (var l in Infrastructure.AllFiles(folderpath + @"\.dik")) 
            {
                if (l == folderpath + @"\.dik\dikignore.dikignore")
                {
                    v.Remove(new Element() { Name = l, Content = File.ReadAllText(l), Extent = Path.GetExtension(l)});
                }
            }

            string s = JsonConvert.SerializeObject(v);
            File.WriteAllText(folderpath + @"\.dik" + @"\" + name + ".dik", s);
            foreach (var f in v)
            {
                Console.WriteLine(f);
            }
        }

        //public static void Extract(string filepath, string folderpath) 
        //{
        //    List<Element> elements = new List<Element>();

        //    if (!File.Exists(filepath)) 
        //    {
        //        Console.WriteLine("No such file path!!!");
        //    }
        //    if (!Directory.Exists(folderpath)) 
        //    {
        //        Console.WriteLine("No such directory path!!!");
        //    }

        //    //JArray jsonResponse = JArray.Parse(File.ReadAllText(filepath));

        //    //foreach (var item in jsonResponse)
        //    //{
        //    //    JObject jRaces = (JObject)item[""];
        //    //    foreach (var rItem in jRaces)
        //    //    {
        //    //        string rItemKey = rItem.Key;
        //    //        JObject rItemValueJson = (JObject)rItem.Value;
        //    //        elements.Add(item.Value<JObject>().ToObject<Element>());
        //    //    }
        //    //}
        //    elements = JsonConvert.DeserializeObject<List<Element>>(File.ReadAllText(filepath));
        //    foreach (var i in elements) 
        //    {
        //        Console.WriteLine(i);
        //        Console.WriteLine(folderpath + @"\" + i.Name);
        //        File.Create(folderpath +@"\"+ i.Name);
        //        File.WriteAllText(folderpath + @"\" + i.Name, i.Content);
        //    }
        //}

        public static void DikDelete(string folderpath)
        {
            if (!Directory.Exists(folderpath + @"\.dik"))
            {
                Console.WriteLine("Project not initialised!!!");
                return;
            }
            File.Delete(folderpath + @"\.dik");
        }

        public static void GetBranches(string folderpath) 
        {
            bool u = true;
            List<Element> a = Infrastructure.AllElementsInFolder(folderpath + @"\.dik", u);
            foreach (var i in a)
            {
                if (i.Extent == ".dik")
                {
                    Console.WriteLine(i.Name);
                }
            }
        }
    }
}
