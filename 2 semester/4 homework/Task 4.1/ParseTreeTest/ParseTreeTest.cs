using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4._1;

namespace ParseTreeTest
{
    [TestClass]
    public class ParseTreeTest
    {
        private ConstructParseTree tree;

        [TestMethod]
        public void Test1()
        {
            tree = ReadingFile.ReadFromFile("expression.txt"); // выражение в файле: *-529
            Assert.AreEqual(tree.PrintParseTree(), " * - 5 2 9");
            Assert.AreEqual(tree.CalculateTree(), 27);
        }

        [TestMethod]
        public void Test2()
        {
            tree = ReadingFile.ReadFromFile("expression.txt"); // выражение в файле: - *5  2 9
            Assert.AreEqual(tree.PrintParseTree(), " - * 5 2 9");
            Assert.AreEqual(tree.CalculateTree(), 1);
        }

        [TestMethod]
        public void Test3()
        {
            tree = ReadingFile.ReadFromFile("expression.txt"); // выражение в файле: ( * ( + 1 1 ) 2 )
            Assert.AreEqual(tree.PrintParseTree(), " * + 1 1 2");
            Assert.AreEqual(tree.CalculateTree(), 4);
        }

        [TestMethod]
        public void Test4()
        {
            tree = ReadingFile.ReadFromFile("expression.txt");  // выражение в файле: * 8 + / - 7 3 2 1
            Assert.AreEqual(tree.PrintParseTree(), " * 8 + / - 7 3 2 1");
            Assert.AreEqual(tree.CalculateTree(), 24);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ExistFile()
        {
            tree = ReadingFile.ReadFromFile("file");
        }
    }
}
