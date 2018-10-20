using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLibrary.ResultStructure;
using AssemblyBrowserLibrary;
using System.Linq;

namespace AssembyBrowserUnitTest
{
    [TestClass]
    public class AssemblyBrowserTestClass
    {
        private AssemblyBrowserResult result;
        private Type testClassType;
        private string dllPath = "./AssembyBrowserUnitTest.dll";

        [TestInitialize]
        public void Initialize()
        {
            AssemblyReader asmInfoProcessor = new AssemblyReader();
            result = asmInfoProcessor.Read(dllPath);
            testClassType = typeof(AssemblyBrowserTestClass);
        }

        [TestMethod]
        public void TestNamespacesIsNotNull()
        {
            Assert.IsNotNull(result.Namespaces);
        }

        [TestMethod]
        public void TestNamespacesCount()
        {
            Assert.IsTrue(result.Namespaces.Count > 0);
        }

        [TestMethod]
        public void TestNamespaceName()
        {
            Assert.AreEqual(result.Namespaces[0].Name, nameof(AssembyBrowserUnitTest));
        }

        [TestMethod]
        public void TestNamespacesTypesCount()
        {
            foreach (Namespace ns in result.Namespaces)
            {
                Assert.IsTrue(ns.DataTypes.Count > 0);
            }
        }

        [TestMethod]
        public void TestTypeFieldsCount()
        {
            int actualCount = result.Namespaces[0].DataTypes[0].fields.Count;
            int expectedCount = testClassType.GetFields().Length;
            Assert.AreEqual(actualCount, expectedCount);
        }

        [TestMethod]
        public void TestTypePropertiesCount()
        {
            int actualCount = result.Namespaces[0].DataTypes[0].properties.Count;
            int expectedCount = testClassType.GetProperties().Length;

            Assert.AreEqual(actualCount, expectedCount);
        }

        [TestMethod]
        public void TestTypeMethodsCount()
        {
            int actualCount = result.Namespaces[0].DataTypes[0].methods.Count;
            int expectedCount = testClassType.GetMethods().Where(item => !item.IsSpecialName).Count();
            Assert.AreEqual(actualCount, expectedCount);
        }
    }
}
