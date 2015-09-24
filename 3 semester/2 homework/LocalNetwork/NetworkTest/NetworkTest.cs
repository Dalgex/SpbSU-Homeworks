using System;
using Network;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkTest
{
    [TestClass]
    public class NetworkTest
    {
        private LocalNetwork network;

        [TestMethod]
        public void Test1()
        {
            network = new LocalNetwork();
            network.ReadFromFile("network1.txt");
            Assert.AreEqual(network.PrintNumberInfectedComps(), "1 ");
            network.Move();
            Assert.AreEqual(network.PrintNumberInfectedComps(), "0 1 ");
            network.Move();
            Assert.AreEqual(network.PrintNumberInfectedComps(), "0 1 2 ");
        }

        [TestMethod]
        public void Test2()
        {
            network = new LocalNetwork();
            network.ReadFromFile("network2.txt");
            Assert.AreEqual(network.PrintNumberInfectedComps(), "1 3 ");
            network.Move();
            Assert.AreEqual(network.PrintNumberInfectedComps(), "0 1 2 3 ");
        }

        [TestMethod]
        public void Test3()
        {
            network = new LocalNetwork();
            network.ReadFromFile("network3.txt");
            Assert.AreEqual(network.PrintNumberInfectedComps(), "0 3 ");
            network.Move();
            Assert.AreEqual(network.PrintNumberInfectedComps(), "0 1 3 4 ");
            network.Move();
            Assert.AreEqual(network.PrintNumberInfectedComps(), "0 1 2 3 4 ");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ExistFile()
        {
            network = new LocalNetwork();
            network.ReadFromFile("file.txt");
        }
    }
}
