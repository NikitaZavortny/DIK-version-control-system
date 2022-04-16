using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dik.models;

namespace dik
{
    class Infrastructure
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
            Folder f = new Folder();
            f.Name = folderpath.Split('\\').Last();
            foreach (var a in Directory.GetDirectories(folderpath)) 
            {
                f.folders.Add(folder(a));
            }
            return null;
        }

        public static List<Element> AllElementsInFolder(string folderpath, bool GetBranches)
        {
            List <Element> elements = new List<Element>();
            foreach (var i in AllFiles(folderpath)) 
            {
                if (Path.GetExtension(i) != ".dik" || GetBranches == true)
                {
                    elements.Add(new Element() { Name = Path.GetFileName(i), Path = i, Content = File.ReadAllText(i), Extent = Path.GetExtension(i), f = folder(folderpath)});
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
    }
}