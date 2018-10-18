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
            if (mi.GetGenericArguments().Length != 0)
                name = GetGenericName(mi);
            else
                name = mi.Name;
            signature = "" + mi.ReturnType.Name + " (";

            ParameterInfo[] pi = mi.GetParameters();
            foreach(ParameterInfo param in pi)
            {
                signature = signature + " " + param.ParameterType.Name + " " + param.Name;
            }

            signature = signature + ")";
        }

        private string GetGenericName(MethodInfo mi)
        {
            string result = "" + mi.Name + " <";

            foreach(Type t in mi.GetGenericArguments())
            {
                result = result + t.Name;
            }

            return result + ">";
        }
    }
}
