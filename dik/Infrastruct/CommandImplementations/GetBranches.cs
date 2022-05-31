using dik.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dik.Infrastruct.CommandImplementations
{
    class GetBranches : Command
    {
        public string Name { get; set; } = "getbranches";

        public void Execute(params string[] q)
        {
            bool u = true;
            List<Element> a = FileInfrastructure.AllElementsInFolder(q[1] + @"\.dik", q[1] + @"\.dik", u);
            foreach (var i in a)
            {
                if (i.Extent == ".dik")
                {

                    Console.WriteLine(i.Name);
                }
            }
        }
    }
}
