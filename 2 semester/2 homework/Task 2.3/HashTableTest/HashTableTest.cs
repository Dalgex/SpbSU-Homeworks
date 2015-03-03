using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2._3;

namespace Task_2._3.Tests
{
    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable;

        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable();
        }

        [TestMethod]
        public void AddElementTest()
        {
            hashTable.AddElementHashTable("abcd");
            hashTable.AddElementHashTable("123");
            Assert.IsTrue(hashTable.Contains("abcd"));
            hashTable.AddElementHashTable("2+5");
            Assert.IsTrue(hashTable.Contains("2+5"));
            Assert.IsTrue(hashTable.Contains("123"));
        }

        [TestMethod]
        public void RemoveElementTest()
        {
            hashTable.AddElementHashTable("hello");
            hashTable.AddElementHashTable("world");
            hashTable.AddElementHashTable("hello");
            hashTable.AddElementHashTable("hello");
            Assert.IsFalse(hashTable.RemoveElement("2+5"));
            Assert.IsTrue(hashTable.RemoveElement("world"));
            Assert.IsFalse(hashTable.Contains("world"));
            Assert.IsTrue(hashTable.RemoveElement("hello"));
            Assert.IsFalse(hashTable.Contains("hello"));
        }
    }
}
