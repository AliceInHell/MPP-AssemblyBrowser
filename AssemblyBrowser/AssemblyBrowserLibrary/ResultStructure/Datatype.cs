using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssemblyBrowserLibrary.ResultStructure
{
    public class Datatype
    {
        public string Name { set; get; }
        public string DataTypeInfo { set; get; }
        public List<Field> fields;
        public List<Property> properties;
        public List<Method> methods;

        public Datatype(TypeInfo t)
        {
            Name = AtributeBuilder.GetAtributes(t) + t.Name;
            fields = new List<Field>();
            properties = new List<Property>();
            methods = new List<Method>();

            GetFields(t);
            GetProperties(t);
            GetMethods(t);

            CollectTypeInfo();
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

        private void CollectTypeInfo()
        {
            DataTypeInfo = "\tFields:\n\t\t";

            foreach (Field f in fields)
                DataTypeInfo += f.type + " " + f.name + "\n\t\t";

            DataTypeInfo += "\n\tProperties\n\t\t";

            foreach (Property p in properties)
                DataTypeInfo += p.type + " " + p.name + "\n\t\t";

            DataTypeInfo += "\n\tMethods\n\t\t";

            foreach (Method m in methods)
                DataTypeInfo += m.signature + m.name + "\n\t\t";

            this.DataTypeInfo = DataTypeInfo;
        }
    }
}
