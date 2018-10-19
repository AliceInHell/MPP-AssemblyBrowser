using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class Method
    {
        public string name;
        public string signature;

        public Method(MethodInfo mi)
        {
            signature = AtributeBuilder.GetTypeModifiers(mi.GetType()) + mi.ToString();
        }
    }
}
