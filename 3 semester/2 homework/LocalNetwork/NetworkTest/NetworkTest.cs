using System;
using Network;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkTest
{
    [TestClass]
    public class NetworkTest
    {
        private LocalNetwork netWork;

        [TestMethod]
        public void Test1()
        {
            netWork = new LocalNetwork();
            netWork.ReadFromFile("network1.txt");
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "1 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 2 ");
        }

        [TestMethod]
        public void Test2()
        {
            netWork = new LocalNetwork();
            netWork.ReadFromFile("network2.txt");
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "1 3 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 2 3 ");
        }

        [TestMethod]
        public void Test3()
        {
            netWork = new LocalNetwork();
            netWork.ReadFromFile("network3.txt");
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 3 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 3 4 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 3 4 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 2 3 4 ");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ExistFile()
        {
            netWork = new LocalNetwork();
            netWork.ReadFromFile("file.txt");
        }
    }
}
