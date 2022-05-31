using dik.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dik.Infrastruct.CommandImplementations
{
    class Extract : Command
    {
        public string Name { get; set; } = "extract";

        public void Execute(params string[] a)
        {
            if (a.Length < 2)
            {
                TextInfrastruct.WriteError("No path to file!!!");
            }
            if (a.Length < 3)
            {
                TextInfrastruct.WriteError("No path to folder of extraction!!!");
            }

            if (!File.Exists(a[1]))
            {
                Console.WriteLine("No such file path!!!");
            }
            if (!Directory.Exists(a[2]))
            {
                Console.WriteLine("No such directory path!!!");
            }

            FileStruct fileTree = JsonConvert.DeserializeObject<FileStruct>(File.ReadAllText(a[1]));

            TextInfrastruct.WriteSucess("Starting folder extraction:", "Start");

            FileInfrastructure.ExtractFolders(fileTree.f, a[2]);

            TextInfrastruct.WriteSucess("Starting files extraction:", "Start");

            FileInfrastructure.ExtractFiles(a[2], fileTree.elements);

        }
    }
}
