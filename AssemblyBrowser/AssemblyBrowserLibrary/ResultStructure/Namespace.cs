using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class Namespace
    {
        public string name;

        public List<Datatype> dataTypes;

        public Namespace(string name)
        {
            this.name = name;
            dataTypes = new List<Datatype>();
        }
    }
}
