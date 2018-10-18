using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class AssemblyBrowserResult
    {
        public List<Namespace> namespaces;

        public AssemblyBrowserResult()
        {
            namespaces = new List<Namespace>();
        }
    }
}
