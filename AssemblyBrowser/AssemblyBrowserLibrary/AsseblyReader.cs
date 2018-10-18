using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyBrowserLibrary.ResultStructure;
using System.Reflection;
using System.Linq;

namespace AssemblyBrowserLibrary
{
    public class AsseblyReader
    {
        private AssemblyBrowserResult _result;

        public AsseblyReader()
        {
            
        }

        public AssemblyBrowserResult Read(string path)
        {
            _result = new AssemblyBrowserResult();

            Assembly asm = Assembly.LoadFrom(path);

            //working with namespaces
            foreach (var type in asm.DefinedTypes)
            {
                if (_result.namespaces.Find(x => x.name == type.Namespace) == null 
                    && type.Namespace != null)
                {
                    _result.namespaces.Add(new Namespace(type.Namespace));
                }
            }

            //working with dataTypes
            foreach (var ns in _result.namespaces)
            {
                foreach (var type in asm.DefinedTypes.Where(x => x.Namespace == ns.name))
                {
                    ns.dataTypes.Add(new Datatype(type));
                }
            }

            return _result;
        }
    }
}
