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
        private Computer[] comp;
        private Network.OperatingSystem[] system;
        private bool[,] matrix;

        [TestMethod]
        public void Test1()
        {
            ReadingFile.ReadFromFile("network1.txt", out comp, out system, out matrix);
            netWork = new LocalNetwork(comp, system, matrix);
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "1 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 2 ");
        }
        
        [TestMethod]
        public void Test2()
        {
            ReadingFile.ReadFromFile("network2.txt", out comp, out system, out matrix);
            netWork = new LocalNetwork(comp, system, matrix);
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "1 3 ");
            netWork.Move();
            Assert.AreEqual(netWork.PrintNumberInfectedComps(), "0 1 2 3 ");
        }

        [TestMethod]
        public void Test3()
        {
            ReadingFile.ReadFromFile("network3.txt", out comp, out system, out matrix);
            netWork = new LocalNetwork(comp, system, matrix);
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
            ReadingFile.ReadFromFile("file.txt", out comp, out system, out matrix);
        }
    }
}
