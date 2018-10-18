using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class Field
    {
        public string name;
        public string type;

        public Field(FieldInfo fi)
        {
            name = fi.Name;
            type = fi.FieldType.Name;
        }
    }
}
