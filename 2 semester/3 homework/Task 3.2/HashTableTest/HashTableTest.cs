using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_3._2;

namespace Task_3._2.Test
{
    [TestClass]
    public class HashTableTest
    {
        private HashTable hashTable;

        [TestMethod]
        public void AddTest()
        {
            hashTable = new HashTable();
            AddElementsTest();
        }

        [TestMethod]
        public void RemoveTest()
        {
            hashTable = new HashTable();
            RemoveElementsTest();
        }

        [TestMethod]
        public void AddUsingDelegateTest()
        {
            HashTable.Hashing hashDelegate = new HashTable.Hashing(HashFuncOfUser);
            hashTable = new HashTable(hashDelegate);
            AddElementsTest();
        }

        [TestMethod]
        public void RemoveUsingDelegateTest()
        {
            HashTable.Hashing hashDelegate = new HashTable.Hashing(HashFuncOfUser);
            hashTable = new HashTable(hashDelegate);
            RemoveElementsTest();
        }

        public void AddElementsTest()
        {
            hashTable.AddElementHashTable("abcd");
            hashTable.AddElementHashTable("123");
            Assert.IsTrue(hashTable.Contains("abcd"));
            hashTable.AddElementHashTable("friend");
            Assert.IsTrue(hashTable.Contains("friend"));
            Assert.IsTrue(hashTable.Contains("123"));
        }

        private int HashFuncOfUser(string value)
        {
            int result = 0;

            for (int i = 0; i < value.Length; i++)
            {
                result = (result + (i + 3) * value[i]) % hashTable.Length();
            }

            return result;
        }

        public void RemoveElementsTest()
        {
            hashTable.AddElementHashTable("hello");
            hashTable.AddElementHashTable("world");
            hashTable.AddElementHashTable("hello");
            hashTable.AddElementHashTable("555666");
            Assert.IsTrue(hashTable.RemoveElement("555666"));
            hashTable.AddElementHashTable("hello");
            Assert.IsTrue(hashTable.RemoveElement("world"));
            Assert.IsFalse(hashTable.RemoveElement("world"));
            Assert.IsTrue(hashTable.RemoveElement("hello"));
            Assert.IsFalse(hashTable.Contains("hello"));
            Assert.IsFalse(hashTable.Contains("555666"));
        }
    }
}
