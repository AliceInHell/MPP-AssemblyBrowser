using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class AssemblyBrowserResult
    {
        public List<Namespace> Namespaces { set; get; }

        public AssemblyBrowserResult()
        {
            Namespaces = new List<Namespace>();
        }
    }
}
