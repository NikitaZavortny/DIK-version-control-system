using System;
using System.Collections.Generic;
using System.Text;

namespace dik.models
{
    class Folder
    {
        public string Name { get; set; }
        public List<Folder> folders { get; set; }
    }
}
