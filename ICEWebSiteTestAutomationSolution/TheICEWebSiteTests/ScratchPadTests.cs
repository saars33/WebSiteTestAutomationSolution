using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheICEWebSiteTests
{
    [TestClass]
    public class ScratchPadTests
    {
        [TestInitialize]
        public void MyScratchTestInitializeeMethod()
        {
            Console.WriteLine("inside MyScratchTestInitializeeMethod");    
        }

        [TestMethod]
        public void MyFirstScratchTestMethod()
        {
            Console.WriteLine("inside MyFirstScratchTestMethod");
        }

        [TestCleanup]
        public void MyScratchTestCleanup()
        {
            Console.WriteLine("inside MyScratchTestCleanup");
        }

    }
}
