using System;
using System.Collections.Generic;
using System.IO;
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

        public static List<Element> AllElementsInFolder(string folderpath)
        {
            List <Element> elements = new List<Element>();
            foreach (var i in AllFiles(folderpath)) 
            {
                elements.Add(new Element() { Name = i, Content = File.ReadAllText(i), Extent = Path.GetExtension(i) });
                foreach (var s in Directory.GetDirectories(folderpath)) 
                {
                    foreach (var d in AllElementsInFolder(s)) 
                    {
                        elements.Add(d);
                    }
                }
            }
            return elements;
        }
    }
}
