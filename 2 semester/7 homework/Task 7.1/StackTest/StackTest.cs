using System;
using Task_7._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTest
{
    [TestClass]
    public class StackTest
    {
        private Stack<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<int>();
        }

        [TestMethod]
        public void PushTest()
        {
            stack.Push(13);
            Assert.IsTrue(stack.Contains(13));
            stack.Push(-6);
            Assert.AreEqual(stack.Peek(), -6);
            stack.Push(7);
            Assert.AreEqual(stack.Count, 3);
            stack.Push(10);
            Assert.AreEqual(stack.Peek(), 10);
            Assert.IsTrue(stack.Contains(7));
        }

        [TestMethod]
        public void PopTest()
        {
            stack.Push(11);
            stack.Push(3);
            stack.Push(5);
            Assert.AreEqual(stack.Peek(), 5);
            Assert.AreEqual(stack.Count, 3);
            Assert.AreEqual(stack.Pop(), 5);
            Assert.IsFalse(stack.Contains(5));
            Assert.AreEqual(stack.Peek(), 3);
            Assert.IsTrue(stack.Contains(3));
            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Count, 1);
            Assert.IsFalse(stack.Contains(3));
            stack.Push(13);
            Assert.AreEqual(stack.Pop(), 13);
            Assert.IsTrue(stack.Contains(11));
            Assert.AreEqual(stack.Pop(), 11);
            Assert.IsFalse(stack.Contains(11));
            Assert.AreEqual(stack.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFromEmptyStack()
        {
            stack.Push(13);
            stack.Pop();
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReturnTopValueFromEmptyStack()
        {
            stack.Push(13);
            stack.Pop();
            stack.Peek();
        }
    }
}
