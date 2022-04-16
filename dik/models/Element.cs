using System;
using System.Collections.Generic;
using System.Text;

namespace dik.models
{
    class Element
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public string Extent { get; set; }
        public Folder f { get; set; }
    }
}
