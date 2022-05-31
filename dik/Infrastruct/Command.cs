using System;
using System.Collections.Generic;
using System.Text;

namespace dik.Infrastruct
{
    interface Command
    {
        public string Name { get; set; }

        virtual void Execute(params string[] a) { }
    }
}
