using System;
using Task_5._1;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Map.Test
{
    [TestClass]
    public class MapTest
    {
        private List<int> list;
        private List<int> map1;
        private List<int> map2;

        [TestMethod]
        public void TestMethod1()
        {
            list = new List<int> { 1, 8, 6, 3 };
            map1 = new MapClass<int>().Map(list, x => x * 2);
            Assert.AreEqual(list[0] * 2, map1[0]);
            Assert.AreEqual(list[1] * 2, map1[1]);
            Assert.AreEqual(list[2] * 2, map1[2]);
            Assert.AreEqual(list[3] * 2, map1[3]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            list = new List<int> { 1, 4, 7, 5 };
            map2 = new MapClass<int>().Map(list, x => x * x);
            Assert.AreEqual(list[0] * list[0], map2[0]);
            Assert.AreEqual(list[1] * list[1], map2[1]);
            Assert.AreEqual(list[2] * list[2], map2[2]);
            Assert.AreEqual(list[3] * list[3], map2[3]);
        }
    }
}
