using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using dik.models;
using dik.Infrastruct;
using System.Text;
using Newtonsoft.Json.Linq;

namespace dik.Infrastruct
{
    class CommandImpl
    {
        //public static void dikHelp()
        //{
        //    Console.WriteLine("Welcome to dik - a new version control system :)");
        //    Console.WriteLine("newbranch  -<folder path> -<branch name>  - make branch");
        //    Console.WriteLine("newbranch  -<folder path> -<branch name>  - make branch");
        //    Console.WriteLine("delete  -<folderpath>                     - delete all .dik files");
        //    Console.WriteLine("extract  -<file path> -<folder path>      - delete all .dik files");
        //}

        //public static void dikbranch(string folderpath, string name)
        //{
        //    if (!Directory.Exists(folderpath + @"\.dik"))
        //    {
        //        TextInfrastruct.WriteError("Project not initialised!!!");
        //        Console.WriteLine("Init project? y/n");
        //        string g = Console.ReadLine();

        //        if (g == "y")
        //        {
        //            Directory.CreateDirectory(folderpath + @"\.dik");
        //            CommandImpl.dikbranch(folderpath, name);
        //        }

        //        return;
        //    }

        //    Console.WriteLine();
        //    TextInfrastruct.WriteSucess("Starting file registration:", "Start");
        //    Console.WriteLine();

        //    List<Element> v = FileInfrastructure.AllElementsInFolder(folderpath, folderpath, false);

        //    foreach (var l in FileInfrastructure.AllFiles(folderpath + @"\.dik"))
        //    {
        //        if (l == folderpath + @"\.dik\dikignore.dikignore")
        //        {
        //            v.Remove(new Element() { Name = l, Content = File.ReadAllText(l), Extent = Path.GetExtension(l) });
        //        }
        //    }


        //    FileStruct q = new FileStruct();
        //    q.elements = v;
        //    q.f = FileInfrastructure.folder(folderpath);

        //    string s = JsonConvert.SerializeObject(q);
        //    File.WriteAllText(folderpath + @"\.dik" + @"\" + name + ".dik", s);

        //    Console.WriteLine();
        //    TextInfrastruct.WriteSucess("Starting folders registration:", "Start");
        //    Console.WriteLine();

        //    Console.ForegroundColor = ConsoleColor.Green;
        //    foreach (var f in v)
        //    {
        //        Console.WriteLine("     Registered file: " + folderpath + f.Path);
        //    }
        //    Console.ResetColor();
        //}

        //public static void Extract(string filepath, string folderpath)
        //{
        //    if (!File.Exists(filepath))
        //    {
        //        Console.WriteLine("No such file path!!!");
        //    }
        //    if (!Directory.Exists(folderpath))
        //    {
        //        Console.WriteLine("No such directory path!!!");
        //    }

        //    FileStruct fileTree = JsonConvert.DeserializeObject<FileStruct>(File.ReadAllText(filepath));

        //    TextInfrastruct.WriteSucess("Starting folder extraction:", "Start");

        //    FileInfrastructure.ExtractFolders(fileTree.f, folderpath);

        //    TextInfrastruct.WriteSucess("Starting files extraction:", "Start");

        //    FileInfrastructure.ExtractFiles(folderpath, fileTree.elements);

        //}

        //public static void DikDelete(string folderpath)
        //{
        //    if (!Directory.Exists(folderpath + @"\.dik"))
        //    {
        //        Console.WriteLine("Project not initialised!!!");
        //        return;
        //    }
        //    File.Delete(folderpath + @"\.dik");
        //}

        //public static void GetBranches(string folderpath)
        //{
        //    bool u = true;
        //    List<Element> a = FileInfrastructure.AllElementsInFolder(folderpath + @"\.dik", folderpath + @"\.dik", u);
        //    foreach (var i in a)
        //    {
        //        if (i.Extent == ".dik")
        //        {

        //            Console.WriteLine(i.Name);
        //        }
        //    }
        //}
    }
}
