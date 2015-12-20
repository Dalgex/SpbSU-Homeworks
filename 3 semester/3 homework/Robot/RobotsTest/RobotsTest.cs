using System;
using Robot;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotsTest
{
    [TestClass]
    public class RobotsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool[,] adjacencyMatrix = new bool[3, 3];
            adjacencyMatrix[0, 0] = true;
            adjacencyMatrix[0, 1] = true;
            adjacencyMatrix[0, 2] = false;

            adjacencyMatrix[1, 0] = true;
            adjacencyMatrix[1, 1] = true;
            adjacencyMatrix[1, 2] = true;

            adjacencyMatrix[2, 0] = false;
            adjacencyMatrix[2, 1] = true;
            adjacencyMatrix[2, 2] = true;

            bool[] isRobotHere = new bool[3];
            isRobotHere[0] = true;
            isRobotHere[1] = true;
            isRobotHere[2] = true;

            Graph graph = new Graph(adjacencyMatrix, isRobotHere);
            TeleportationsRobots robots = new TeleportationsRobots(graph);
            Assert.IsFalse(robots.CanAllRobotsBeDestroyed());

            isRobotHere[1] = false;
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool[,] adjacencyMatrix = new bool[4, 4];
            adjacencyMatrix[0, 0] = true;
            adjacencyMatrix[0, 1] = true;
            adjacencyMatrix[0, 2] = true;
            adjacencyMatrix[0, 3] = false;

            adjacencyMatrix[1, 0] = true;
            adjacencyMatrix[1, 1] = true;
            adjacencyMatrix[1, 2] = false;
            adjacencyMatrix[1, 3] = true;

            adjacencyMatrix[2, 0] = true;
            adjacencyMatrix[2, 1] = false;
            adjacencyMatrix[2, 2] = true;
            adjacencyMatrix[2, 3] = true;

            adjacencyMatrix[3, 0] = false;
            adjacencyMatrix[3, 1] = true;
            adjacencyMatrix[3, 2] = true;
            adjacencyMatrix[3, 3] = true;

            bool[] isRobotHere = new bool[4];
            isRobotHere[0] = true;
            isRobotHere[1] = true;
            isRobotHere[2] = true;
            isRobotHere[3] = true;

            Graph graph = new Graph(adjacencyMatrix, isRobotHere);
            TeleportationsRobots robots = new TeleportationsRobots(graph);
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());

            isRobotHere[2] = false;
            Assert.IsFalse(robots.CanAllRobotsBeDestroyed());

            isRobotHere[1] = false;
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool[,] adjacencyMatrix = new bool[5, 5];
            adjacencyMatrix[0, 0] = true;
            adjacencyMatrix[0, 1] = false;
            adjacencyMatrix[0, 2] = true;
            adjacencyMatrix[0, 3] = false;
            adjacencyMatrix[0, 4] = false;

            adjacencyMatrix[1, 0] = false;
            adjacencyMatrix[1, 1] = true;
            adjacencyMatrix[1, 2] = false;
            adjacencyMatrix[1, 3] = true;
            adjacencyMatrix[1, 4] = true;

            adjacencyMatrix[2, 0] = true;
            adjacencyMatrix[2, 1] = false;
            adjacencyMatrix[2, 2] = true;
            adjacencyMatrix[2, 3] = true;
            adjacencyMatrix[2, 4] = false;

            adjacencyMatrix[3, 0] = false;
            adjacencyMatrix[3, 1] = true;
            adjacencyMatrix[3, 2] = true;
            adjacencyMatrix[3, 3] = true;
            adjacencyMatrix[3, 4] = false;

            adjacencyMatrix[4, 0] = false;
            adjacencyMatrix[4, 1] = true;
            adjacencyMatrix[4, 2] = false;
            adjacencyMatrix[4, 3] = false;
            adjacencyMatrix[4, 4] = true;

            bool[] isRobotHere = new bool[5];
            isRobotHere[0] = true;
            isRobotHere[1] = true;
            isRobotHere[2] = true;
            isRobotHere[3] = true;
            isRobotHere[4] = true;

            Graph graph = new Graph(adjacencyMatrix, isRobotHere);
            TeleportationsRobots robots = new TeleportationsRobots(graph);
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());

            isRobotHere[1] = false;
            Assert.IsFalse(robots.CanAllRobotsBeDestroyed());

            isRobotHere[3] = false;
            Assert.IsFalse(robots.CanAllRobotsBeDestroyed());

            isRobotHere[2] = false;
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());
        }

        [TestMethod]
        public void TestMethod4()
        {
            bool[,] adjacencyMatrix = new bool[6, 6];
            adjacencyMatrix[0, 0] = true;
            adjacencyMatrix[0, 1] = false;
            adjacencyMatrix[0, 2] = false;
            adjacencyMatrix[0, 3] = true;
            adjacencyMatrix[0, 4] = false;
            adjacencyMatrix[0, 5] = false;

            adjacencyMatrix[1, 0] = true;
            adjacencyMatrix[1, 1] = false;
            adjacencyMatrix[1, 2] = true;
            adjacencyMatrix[1, 3] = false;
            adjacencyMatrix[1, 4] = true;
            adjacencyMatrix[1, 5] = false;

            adjacencyMatrix[2, 0] = false;
            adjacencyMatrix[2, 1] = true;
            adjacencyMatrix[2, 2] = true;
            adjacencyMatrix[2, 3] = false;
            adjacencyMatrix[2, 4] = false;
            adjacencyMatrix[2, 5] = true;

            adjacencyMatrix[3, 0] = true;
            adjacencyMatrix[3, 1] = false;
            adjacencyMatrix[3, 2] = true;
            adjacencyMatrix[3, 3] = false;
            adjacencyMatrix[3, 4] = false;
            adjacencyMatrix[3, 5] = false;

            adjacencyMatrix[4, 0] = false;
            adjacencyMatrix[4, 1] = true;
            adjacencyMatrix[4, 2] = false;
            adjacencyMatrix[4, 3] = true;
            adjacencyMatrix[4, 4] = true;
            adjacencyMatrix[4, 5] = true;

            adjacencyMatrix[5, 0] = false;
            adjacencyMatrix[5, 1] = false;
            adjacencyMatrix[5, 2] = true;
            adjacencyMatrix[5, 3] = false;
            adjacencyMatrix[5, 4] = true;
            adjacencyMatrix[5, 5] = true;

            bool[] isRobotHere = new bool[6];
            isRobotHere[0] = true;
            isRobotHere[1] = true;
            isRobotHere[2] = true;
            isRobotHere[3] = true;
            isRobotHere[4] = true;
            isRobotHere[5] = true;

            Graph graph = new Graph(adjacencyMatrix, isRobotHere);
            TeleportationsRobots robots = new TeleportationsRobots(graph);
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());

            isRobotHere[4] = false;
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());

            isRobotHere[3] = false;
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());

            isRobotHere[0] = false;
            Assert.IsFalse(robots.CanAllRobotsBeDestroyed());

            isRobotHere[2] = false;
            Assert.IsTrue(robots.CanAllRobotsBeDestroyed());

            isRobotHere[5] = false;
            Assert.IsFalse(robots.CanAllRobotsBeDestroyed());
        }
    }
}
