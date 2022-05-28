using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using dik.models;
using dik.Infrastruct;
using System.Text;
using Newtonsoft.Json.Linq;

namespace dik
{
    class Program
    {
        static void Main(string[] args)
        {
            //OperateCommands(new string[] { "newbranch", @"D:\Новаяпапка", "newstruct8" });
            FileInfrastructure.ExtractFolders(JsonConvert.DeserializeObject<List<Element>>(File.ReadAllText(@"D:\Новаяпапка\.dik\newstruct8.dik"))[0].f, @"D:\extractF");
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
                        TextInfrastruct.WriteError("No path to folder!!!");
                    }
                    if (a.Length < 3) 
                    {
                        TextInfrastruct.WriteError("No name for branch!!!");
                    }
                    CommandImpl.dikbranch(a[1], a[2]);
                    break;

                case "init":
                    if (a.Length < 2) 
                    {
                        TextInfrastruct.WriteError("No path to folder!!!");
                    }
                    Directory.CreateDirectory(a[1]+@"\.dik");
                    break;

                case "delete":
                    if (a.Length < 2)
                    {
                        TextInfrastruct.WriteError("No path to folder!!!");
                    }
                    CommandImpl.DikDelete(a[1]);
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
                    if (a.Length < 1)
                    {
                        TextInfrastruct.WriteError("No path to folder!!!");
                    }
                    CommandImpl.GetBranches(a[1]);
                    break;

                default:
                    TextInfrastruct.WriteError("Unknown Command!!!");
                    break;
            }
        }
    }
}
