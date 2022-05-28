using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dik.models;

namespace dik.Infrastruct
{
    class FileInfrastructure
    {
        public String FileText(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException();
            }
            return File.ReadAllText(path);
        }

        public static IEnumerable<String> AllFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }

        public static Folder folder(string folderpath) 
        {
            Folder f = new Folder() { folders = new List<Folder>()};
            f.Name = folderpath.Split('\\').Last();
            foreach (var a in Directory.GetDirectories(folderpath)) 
            {
                Console.WriteLine(a);
                if (!(folder(a) == null))
                {
                    f.folders.Add(folder(a));
                }
            }
            return f;
        }

        public static List<Element> AllElementsInFolder(string folderpath, bool GetBranches)
        {
            List <Element> elements = new List<Element>();
            foreach (var i in AllFiles(folderpath)) 
            {
                if (Path.GetExtension(i) != ".dik" || GetBranches == true)
                {
                    elements.Add(new Element() { Name = Path.GetFileName(i), Path = i.Remove(0, folderpath.Length), Content = File.ReadAllText(i), Extent = Path.GetExtension(i), f = folder(folderpath)});
                }
            }
            foreach (var s in Directory.GetDirectories(folderpath))
            {
                foreach (var d in AllElementsInFolder(s, GetBranches))
                {
                    if (Path.GetExtension(d.Name) != "dik")
                    {
                        elements.Add(d);
                    }
                }
            }
            return elements;
        }

        public static void ExtractFolders(Folder f, string startfpath) 
        {
            foreach (var i in f.folders)
            {
                Directory.CreateDirectory(startfpath + "\\" + i.Name);
                Console.WriteLine(i.Name + " extracted to " + startfpath + "\\" + i.Name);
                foreach (var a in i.folders)
                {
                    ExtractFolders(i, startfpath + "\\" + i.Name);
                }
            }
        }
    }
}