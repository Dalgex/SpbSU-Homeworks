using System;
using Test_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueTest
{
    [TestClass]
    public class QueueTest
    {
        private PriorityQueue<int> queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new PriorityQueue<int>();
        }

        [TestMethod]
        public void EnqueueTest()
        {
            queue.Enqueue(5, 8);
            Assert.AreEqual(1, queue.Count);
            queue.Enqueue(3, 6);
            queue.Enqueue(7, 9);
            Assert.AreEqual(3, queue.Count);
        }

        [TestMethod]
        public void DequeueTest()
        {
            queue.Enqueue(2, 8);
            queue.Enqueue(5, 5);
            queue.Enqueue(4, 8);
            queue.Enqueue(7, 6);
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(7, queue.Dequeue());
            queue.Enqueue(1, 4);
            queue.Enqueue(3, 10);
            Assert.AreEqual(3, queue.Dequeue());
            queue.Enqueue(4, 2);
            Assert.AreEqual(5, queue.Dequeue());
            queue.Enqueue(9, 8);
            Assert.AreEqual(9, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(4, queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddElements()
        {
            queue.Enqueue(5, 8);
            queue.Dequeue();
            queue.Dequeue();
        }
    }
}
