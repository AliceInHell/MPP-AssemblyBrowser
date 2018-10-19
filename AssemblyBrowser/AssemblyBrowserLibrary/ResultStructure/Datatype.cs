using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class Datatype
    {
        public string name;
        public List<Field> fields;
        public List<Property> properties;
        public List<Method> methods;

        public Datatype(TypeInfo t)
        {
            name = AtributeBuilder.GetAtributes(t) + t.Name;
            fields = new List<Field>();
            properties = new List<Property>();
            methods = new List<Method>();

            GetFields(t);
            GetProperties(t);
            GetMethods(t);
        }

        private void GetFields(Type t)
        {
            var fields = t.GetFields();

            foreach (var field in fields)
            {
                this.fields.Add(new Field(field));
            }
        }

        private void GetProperties(Type t)
        {
            var properties = t.GetProperties();

            foreach (var property in properties)
            {
                this.properties.Add(new Property(property));
            }
        }

        private void GetMethods(Type t)
        {
            var methods = t.GetMethods();

            foreach (var method in methods)
            {
                if (!method.IsSpecialName)
                {
                    this.methods.Add(new Method(method));
                }
            }
        }
    }
}
