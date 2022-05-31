using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dik.Infrastruct.CommandImplementations
{
    class Delete : Command
    {
        public string Name { get; set; } = "delete";

        public void Execute(params string[] a)
        {
            if (a.Length < 1)
            {
                TextInfrastruct.WriteError("No path to folder!!!");
                return;
            }

            if (!Directory.Exists(a[1] + @"\.dik"))
            {
                Console.WriteLine("Project not initialised!!!");
                return;
            }
            File.Delete(a[1] + @"\.dik");
        }
    }
}
