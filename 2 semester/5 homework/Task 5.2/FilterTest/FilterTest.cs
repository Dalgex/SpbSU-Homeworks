using System;
using Task_5._2;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilterTest
{
    [TestClass]
    public class FilterTest
    {
        private List<int> list;
        private List<int> filter1;
        private List<int> filter2;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int> { 1, 10, 6, 3 };
            filter1 = new FilterClass<int>().Filter(list, x => x % 2 == 0);
            filter2 = new FilterClass<int>().Filter(list, x => x % 3 == 1);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(filter1[0] == 10 && filter1[1] == 6 && filter1.Count == 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(filter2[0] == 1 && filter2[1] == 10 && filter2.Count == 2);
        }
    }
}
