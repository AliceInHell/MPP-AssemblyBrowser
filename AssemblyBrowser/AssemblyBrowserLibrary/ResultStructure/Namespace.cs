using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class Namespace
    {
        public string Name { set; get; }

        public List<Datatype> DataTypes { set; get; }

        public Namespace(string name)
        {
            this.Name = name;
            DataTypes = new List<Datatype>();
        }
    }
}
