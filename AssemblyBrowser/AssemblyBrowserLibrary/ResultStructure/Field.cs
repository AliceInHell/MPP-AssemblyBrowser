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
            type = AtributeBuilder.GetTypeModifiers(fi.GetType());

            if(fi.FieldType.IsGenericType)
                type += fi.FieldType.Name + "<" + 
                    GetGenericType(fi.FieldType.GenericTypeArguments) + ">";
            else
                type += fi.FieldType.Name;
        }

        private string GetGenericType(Type[] t)
        {
            string result = "";
            foreach(Type genericType in t)
            {
                if (t.GetType().IsGenericType)
                    result += "<" + GetGenericType(genericType.GetType().GenericTypeArguments) + ">";
                else
                    result += genericType.Name + " ";
            }

            return result;
        }
    }
}
