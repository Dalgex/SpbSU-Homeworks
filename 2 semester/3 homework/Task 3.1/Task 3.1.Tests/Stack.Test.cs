using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_3._1;

namespace Task_3._1.Tests
{
    [TestClass]
    public class StackTest
    {
        private Stack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack();
        }

        [TestMethod]
        public void PushTest()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
            stack.Push(3);
            Assert.AreEqual(2, stack.Size());
        }

        [TestMethod]
        public void PopTest()
        {
            stack.Push(4);
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
            stack.Push(5);
            Assert.AreEqual(5, stack.Pop());
            Assert.AreEqual(1, stack.Size());
            Assert.AreEqual(4, stack.Pop());
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
