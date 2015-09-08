using System;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        private BinaryTree<int> tree;

        [TestInitialize]
        public void Initialize()
        {
            tree = new BinaryTree<int>();
        }

        private void AddElements()
        {
            tree.Add(5);
            tree.Add(7);
            tree.Add(4);
            tree.Add(9);
            tree.Add(2);
        }

        [TestMethod]
        public void AddTest()
        {
            Assert.IsTrue(tree.IsEmpty());
            AddElements();
            Assert.IsFalse(tree.IsEmpty());
            Assert.IsTrue(tree.IsContains(7) && tree.IsContains(2));
            Assert.IsTrue(tree.IsContains(5) && tree.IsContains(4));
            tree.Add(6);
            Assert.IsTrue(tree.IsContains(6) && tree.IsContains(9));
        }

        [TestMethod]
        public void ForeachTest()
        {
            for (int i = 0; i < 5; i++)
            {
                tree.Add(i);
            }

            int j = 0;

            foreach (var value in tree)
            {
                Assert.AreEqual(value, j);
                j++;
            }
        }

        [TestMethod]
        public void IteratorTest()
        {
            for (int i = 5; i < 9; i++)
            {
                tree.Add(i);
            }

            var iterator = tree.GetEnumerator();
            string line = string.Empty;

            while (iterator.MoveNext())
            {
                line += iterator.Current;
            }

            Assert.AreEqual(line, "5678");
            iterator.Reset();

            while (iterator.MoveNext())
            {
                line += iterator.Current;
            }

            Assert.AreEqual(line, "56785678");
        }

        [TestMethod]
        public void RemoveTest()
        {
            AddElements();
            tree.Remove(5);
            Assert.IsFalse(tree.IsContains(5));
            tree.Remove(4);
            tree.Remove(7);
            Assert.IsFalse(tree.IsContains(4) || tree.IsContains(7));
            tree.Add(5);
            tree.Add(5);
            Assert.IsTrue(tree.IsContains(5));
            tree.Remove(9);
            tree.Remove(5);
            Assert.IsFalse(tree.IsEmpty());
            tree.Remove(2);
            Assert.IsFalse(tree.IsContains(5) || tree.IsContains(2));
            Assert.IsTrue(tree.IsEmpty());
            Assert.IsFalse(tree.IsContains(10));
            tree.Remove(10);
        }
    }
}
