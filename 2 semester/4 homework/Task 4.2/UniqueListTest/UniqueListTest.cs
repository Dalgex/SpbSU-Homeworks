using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4._2;

namespace Task_4._2.Tests
{
    [TestClass]
    public class UniqueListTest
    {
        private UniqueList list;
        
        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        public void AddElementsTest()
        {
            list.AddListElement(5);
            Assert.IsTrue(list.Contains(5));
            list.AddListElement(7);
            Assert.AreEqual(2, list.Count());
            Assert.IsTrue(list.Contains(7));
        }

        [TestMethod]
        public void RemoveElementsTest()
        {
            list.AddListElement(4);
            list.AddListElement(3);
            list.AddListElement(5);
            Assert.AreEqual(3, list.Count());
            Assert.IsTrue(list.RemoveListElement(3));
            Assert.IsFalse(list.Contains(3));
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.RemoveListElement(5));
            Assert.AreEqual(1, list.Count());
            Assert.IsFalse(list.Contains(5));
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.RemoveListElement(4));
            Assert.IsFalse(list.Contains(4));
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(RemoveNonexistentElementException))]
        public void RemoveElements()
        {
            list.AddListElement(4);
            list.RemoveListElement(5);
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistentElementException))]
        public void AddElements()
        {
            list.AddListElement(4);
            list.AddListElement(4);
        }
    }
}
