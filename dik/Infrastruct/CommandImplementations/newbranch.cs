using dik.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dik.Infrastruct.CommandImplementations
{
    class newbranch : Command
    {
        public string Name { get; set; } = "newbranch";

        public void Execute(params string[] a)
        {
            if (!Directory.Exists(a[1] + @"\.dik"))
            {
                TextInfrastruct.WriteError("Project not initialised!!!");
                Console.WriteLine("Init project? y/n");
                string g = Console.ReadLine();

                if (g == "y")
                {
                    Directory.CreateDirectory(a[1] + @"\.dik");

                    Execute(a);
                }

                return;
            }

            Console.WriteLine();
            TextInfrastruct.WriteSucess("Starting file registration:", "Start");
            Console.WriteLine();

            List<Element> v = FileInfrastructure.AllElementsInFolder(a[1], a[1], false);

            foreach (var l in FileInfrastructure.AllFiles(a[1] + @"\.dik"))
            {
                if (l == a[1] + @"\.dik\dikignore.dikignore")
                {
                    v.Remove(new Element() { Name = l, Content = File.ReadAllText(l), Extent = Path.GetExtension(l) });
                }
            }


            FileStruct q = new FileStruct();
            q.elements = v;
            q.f = FileInfrastructure.folder(a[1]);

            string s = JsonConvert.SerializeObject(q);
            File.WriteAllText(a[1] + @"\.dik" + @"\" + a[2] + ".dik", s);

            Console.WriteLine();
            TextInfrastruct.WriteSucess("Starting folders registration:", "Start");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var f in v)
            {
                Console.WriteLine("     Registered file: " + a[1] + f.Path);
            }
            Console.ResetColor();
        }
    }
}
