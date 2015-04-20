using System;
using Task_7._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SetTest
{
    [TestClass]
    public class SetTest
    {
        private Set<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();
        }

        private void AddElements()
        {
            set.Add(4);
            set.Add(7);
            set.Add(2);
            set.Add(11);
        }

        [TestMethod]
        public void AddTest()
        {
            AddElements();
            Assert.AreEqual(set.Count, 4);
            Assert.IsTrue(set.Contains(7) && set.Contains(2));
            Assert.IsTrue(set.Contains(4) && set.Contains(11));
            Assert.IsFalse(set.Add(7));
            Assert.AreEqual(set.Count, 4);
        }

        [TestMethod]
        public void RemoveTest()
        {
            AddElements();
            Assert.IsTrue(set.Remove(2));
            Assert.IsFalse(set.Remove(2));
            Assert.AreEqual(set.Contains(2), false);
            Assert.IsTrue(set.Remove(11));
            Assert.IsFalse(set.Contains(11));
            Assert.AreEqual(set.Count, 2);
            Assert.IsTrue(set.Remove(4));
            Assert.IsTrue(set.Remove(7));
            Assert.IsFalse(set.Remove(7));
            Assert.IsFalse(set.Contains(4) || set.Contains(7));
            Assert.AreEqual(set.Count, 0);
        }

        [TestMethod]
        public void UnionTest()
        {
            AddElements();
            Set<int> set1 = new Set<int>();
            set1.Add(5);
            set1.Add(4);
            set1.Add(3);
            Set<int> resultSet = set.UniteSets(set1);
            Assert.AreEqual(resultSet.Count, 6);
            Assert.IsTrue(resultSet.Contains(5) && resultSet.Contains(3));
            Assert.IsTrue(resultSet.Contains(4) && resultSet.Contains(11));
            Assert.IsTrue(resultSet.Contains(2) && resultSet.Contains(7));
            Set<int> set2 = new Set<int>();
            resultSet = set1.UniteSets(set2);
            Assert.AreEqual(resultSet.Count, 3);
            Assert.IsTrue(resultSet.Contains(3) && resultSet.Contains(4) && resultSet.Contains(5));
        }

        [TestMethod]
        public void IntersectTest()
        {
            AddElements();
            Set<int> set1 = new Set<int>();
            set1.Add(7);
            set1.Add(5);
            set1.Add(3);
            set1.Add(4);
            set1.Add(6);
            Set<int> resultSet = set.IntersectSets(set1);
            Assert.AreEqual(resultSet.Count, 2);
            Assert.IsTrue(resultSet.Contains(4) && resultSet.Contains(7));
            Set<int> set2 = new Set<int>();
            resultSet = set1.IntersectSets(set2);
            Assert.AreEqual(resultSet.Count, 0);
        }
    }
}
