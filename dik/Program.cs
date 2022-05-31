using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using dik.models;
using dik.Infrastruct;
using dik.Infrastruct.CommandImplementations;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;

namespace dik
{
    class Program
    {
        static void Main(string[] args)
        {
            OperateCommands(new string[] { "newbranch", @"D:\Новаяпапка", "newstruct2" });
            OperateCommands(new string[] { "extract", @"D:\Новаяпапка\.dik\newstruct2.dik", @"D:\extractF" });
            //FileInfrastructure.ExtractFolders(JsonConvert.DeserializeObject<List<Element>>(File.ReadAllText(@"D:\Новаяпапка\.dik\newstruct8.dik"))[0].f, @"D:\extractF");

            //if (args.Length == 0)
            //{
            //    args[0] = "dik-help";
            //}
            //OperateCommands(args);
        }

        public static void OperateCommands(string[] a)
        {
            List<Command> c = new List<Command>();
            c.Add(new Delete());
            c.Add(new Extract());
            c.Add(new GetBranches());
            c.Add(new Help());
            c.Add(new newbranch());

            foreach (var i in c)
            {
                if (a[0] == i.Name) 
                {
                    i.Execute(a);
                    return;
                }
                
            }
            TextInfrastruct.WriteError("No such command");
            //switch (a[0])
            //{
            //    case "help":
            //        CommandImpl.dikHelp();
            //        break;

            //    case "newbranch":
            //        if (a.Length < 2)
            //        {
            //            TextInfrastruct.WriteError("No path to folder!!!");
            //        }
            //        if (a.Length < 3)
            //        {
            //            TextInfrastruct.WriteError("No name for branch!!!");
            //        }
            //        CommandImpl.dikbranch(a[1], a[2]);
            //        break;

            //    case "init":
            //        if (a.Length < 2)
            //        {
            //            TextInfrastruct.WriteError("No path to folder!!!");
            //        }
            //        Directory.CreateDirectory(a[1] + @"\.dik");
            //        break;

            //    case "delete":
            //        if (a.Length < 1)
            //        {
            //            TextInfrastruct.WriteError("No path to folder!!!");
            //        }
            //        CommandImpl.DikDelete(a[1]);
            //        break;

            //    case "extract":
            //        if (a.Length < 2)
            //        {
            //            TextInfrastruct.WriteError("No path to file!!!");
            //        }
            //        if (a.Length < 3)
            //        {
            //            TextInfrastruct.WriteError("No path to folder of extraction!!!");
            //        }
            //        CommandImpl.Extract(a[1], a[2]);
            //        break;

            //    case "getbranches":
            //        if (a.Length < 1)
            //        {
            //            TextInfrastruct.WriteError("No path to folder!!!");
            //        }
            //        CommandImpl.GetBranches(a[1]);
            //        break;

            //    default:
            //        TextInfrastruct.WriteError("Unknown Command!!!");
            //        break;
            //}

        }
    }
}
