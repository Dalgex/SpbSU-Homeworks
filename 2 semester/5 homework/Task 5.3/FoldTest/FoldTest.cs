using System;
using Task_5._3;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoldTest
{
    [TestClass]
    public class FoldTest
    {
        private List<int> list1;
        private List<int> list2;

        [TestInitialize]
        public void Initialize()
        {
            list1 = new List<int> { 4, 6, 3 };
            list2 = new List<int> { 3, 2, 5, 4 };
        }

        [TestMethod]
        public void TestMethod1()
        {
            int fold = new FoldClass<int>().Fold(list1, 3, (x, y) => x * y);
            Assert.AreEqual(fold, 3 * list1[0] * list1[1] * list1[2]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int fold = new FoldClass<int>().Fold(list2, 7, (x, y) => x * y);
            Assert.IsTrue(fold == 7 * list2[0] * list2[1] * list2[2] * list2[3]);
        }
    }
}
