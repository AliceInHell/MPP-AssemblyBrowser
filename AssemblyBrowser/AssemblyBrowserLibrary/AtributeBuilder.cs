using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AssemblyBrowserLibrary
{
    public static class AtributeBuilder
    {
        public static string GetTypeModifiers(Type ti)
        {
            if (ti.IsNestedPrivate)
                return "private ";
            if (ti.IsNestedFamily)
                return "protected ";
            if (ti.IsNestedAssembly)
                return "internal ";
            if (ti.IsNestedFamORAssem)
                return "protected internal ";
            if (ti.IsNestedFamANDAssem)
                return "protected private ";

            if (ti.IsNestedPublic || ti.IsPublic)
                return "public ";

            if (ti.IsNotPublic)
                return "private ";
            else
                return "public ";
        }

        private static string GetTypeAtributes(Type ti)
        {
            if (ti.IsAbstract && ti.IsSealed)
                return "static ";
            if (ti.IsSealed)
                return "sealed ";
            if (ti.IsAbstract)
                return "abstract ";

            return " ";

        }

        private static string GetTypeClass(Type ti)
        {
            if (ti.IsInterface)
                return "interface ";
            if (ti.IsValueType)
                return "struct ";
            if (ti.IsEnum)
                return "enum ";

            if (ti.BaseType == typeof(MulticastDelegate))
                return "delegate ";

            if (ti.IsClass)
                return "class ";

            return "";

        }
        public static string GetAtributes(Type ti)
        {
            string result = "";

            return result + GetTypeModifiers(ti) + GetTypeAtributes(ti) + GetTypeClass(ti);
        }
    }
}
