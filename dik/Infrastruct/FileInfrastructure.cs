using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using dik.models;

namespace dik.Infrastruct
{
    class FileInfrastructure
    {
        public String FileText(string path)
        {
            if (path == null)
            {
                TextInfrastruct.WriteError("Path is wrong!!!");
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

        public static List<Element> AllElementsInFolder(string folderpath, string startpath, bool GetBranches)
        {
            List <Element> elements = new List<Element>();
            foreach (var i in AllFiles(folderpath)) 
            {
                if (Path.GetExtension(i) != ".dik" || GetBranches == true)
                {
                    elements.Add(new Element() { Name = Path.GetFileName(i), Path = i.Remove(0, startpath.Length), Content = File.ReadAllText(i), Extent = Path.GetExtension(i), f = folder(folderpath)});
                }
            }
            foreach (var s in Directory.GetDirectories(folderpath))
            {
                foreach (var d in AllElementsInFolder(s, startpath, GetBranches))
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
            TextInfrastruct.WriteSucess("Starting folder extraction:", "Start");
            try 
            {
                foreach (var i in f.folders)
                {
                    Directory.CreateDirectory(startfpath + "\\" + i.Name);
                    TextInfrastruct.WriteSucess("Extraction to " + startfpath + "\\" + i.Name, "Extracting");
                    foreach (var a in i.folders)
                    {
                        ExtractFolders(i, startfpath + "\\" + i.Name);
                    }
                }
            }
            catch (Exception e) 
            {
                TextInfrastruct.WriteError(e.Message);
            }
            
        }

        public static void ExtractFiles(string folderpath, List<Element> a)
        {
            TextInfrastruct.WriteSucess("Starting files extraction:", "Start");
            try
            {
                foreach (var i in a)
                {
                    TextInfrastruct.WriteSucess("Extraction to " + folderpath + "\\" + i.Name, "Extracting");
                    using (FileStream sw = File.Create(folderpath + i.Path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(i.Content);

                        sw.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception e)
            {
                TextInfrastruct.WriteError(e.Message);
            }

        }
    }
}