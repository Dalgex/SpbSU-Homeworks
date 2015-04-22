using System;
using Task_7._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListTest
{
    [TestClass]
    public class ListTest
    {
        private List<string> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<string>();
        }

        public void AddElementsTest()
        {
            list.Add("day");
            list.Add("world");
            list.Add("moon");
            list.Add("tree");
        }

        public void InsertElementsTest()
        {
            list.Insert(0, "ticket");
            list.Insert(0, "basketball");
            list.Insert(1, "weather");
            list.Insert(3, "there");
            list.Insert(2, "behaviour");
        }

        [TestMethod]
        public void AddTest()
        {
            AddElementsTest();
            Assert.AreEqual(list.Count, 4);
            Assert.IsTrue(list.Contains("moon") && list.Contains("tree"));
            Assert.IsTrue(list.Contains("day") && list.Contains("world"));
            Assert.AreEqual(list[1], "world");
            Assert.AreEqual(list[3], "tree");
            Assert.AreEqual(list[2], "moon");
            Assert.AreEqual(list[0], "day");
        }

        [TestMethod]
        public void ClearTest()
        {
            AddElementsTest();
            list.Clear();
            Assert.AreEqual(list.Count, 0);
            Assert.IsFalse(list.Contains("tree") || list.Contains("day"));
            Assert.IsFalse(list.Contains("world") || list.Contains("moon"));
        }

        [TestMethod]
        public void CopyTest()
        {
            AddElementsTest();
            string[] str = new string[9];
            string[] line = list.ToArray();
            list.CopyTo(str, 3);
            Assert.IsTrue(str[0] == null && str[1] == null && str[2] == null);
            Assert.IsTrue(line[0] == "day" && str[3] == line[0]);
            Assert.IsTrue(line[1] == "world" && str[4] == line[1]);
            Assert.IsTrue(line[2] == "moon" && str[5] == line[2]);
            Assert.IsTrue(line[3] == "tree" && str[6] == line[3]);
            Assert.IsTrue(str[7] == null && str[8] == null);
        }

        [TestMethod]
        public void InsertTest()
        {
            InsertElementsTest();
            Assert.AreEqual(list.Count, 5);
            Assert.IsTrue(list.Contains("basketball") && list.Contains("there"));
            Assert.IsTrue(list.Contains("behaviour") && list.Contains("weather"));
            Assert.IsTrue(list.Contains("ticket"));
            Assert.AreEqual(list.IndexOf("there"), 4);
            Assert.AreEqual(list.IndexOf("behaviour"), 2);
            Assert.AreEqual(list.IndexOf("ticket"), 3);
            Assert.AreEqual(list.IndexOf("basketball"), 0);
            Assert.AreEqual(list.IndexOf("weather"), 1);
        }

        [TestMethod]
        public void FindTest1()
        {
            InsertElementsTest();
            Assert.AreEqual(list.Find(x => x.Contains("th")), "weather");
            List<string> list1 = list.FindAll(x => x.Contains("ket"));
            Assert.AreEqual(list1.Count, 2);
            Assert.IsTrue(list.Contains("ticket") && list.Contains("basketball"));
            Assert.AreEqual(list.FindIndex(x => x.Contains("th")), 1);
            Assert.IsTrue(list.Exists(x => x.Length == 5));
            Assert.IsTrue(list.TrueForAll(x => x.Contains("e")));
        }

        [TestMethod]
        public void FindTest2()
        {
            AddElementsTest();
            bool isFind = true;
            Assert.AreEqual(list.TryFind(x => x.Contains("oo"), ref isFind), "moon");
            Assert.IsTrue(isFind);
            Assert.AreEqual(list.TryFind(x => x.Length == 6, ref isFind), null);
            Assert.IsFalse(isFind);
        }

        [TestMethod]
        public void ForeachTest()
        {
            for (int i = 0; i < 5; i++)
            {
                list.Add(Convert.ToString(i));
            }

            string line = string.Empty;

            foreach (var value in list)
            {
                line += value;
            }

            Assert.AreEqual(line, "01234");
        }

        [TestMethod]
        public void ReverseTest()
        {
            list.Insert(0, "capital");
            list.Insert(1, "discussion");
            list.Insert(2, "window");
            list.Add("knowledge");
            list.Reverse();
            Assert.AreEqual(list.IndexOf("capital"), 3);
            Assert.AreEqual(list.IndexOf("discussion"), 2);
            Assert.AreEqual(list.IndexOf("window"), 1);
            Assert.AreEqual(list.IndexOf("knowledge"), 0);
        }

        [TestMethod]
        public void RemoveTest()
        {
            InsertElementsTest();
            Assert.AreEqual(list.ToString(), "basketball weather behaviour ticket there ");
            Assert.IsTrue(list.Remove("ticket"));
            Assert.IsFalse(list.Remove("ticket"));
            Assert.AreEqual(list.Count, 4);
            list.RemoveAt(2);
            Assert.IsFalse(list.Contains("behaviour"));
            list.RemoveAt(2);
            Assert.IsFalse(list.Contains("there"));
            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(list.Remove("basketball"));
            Assert.IsFalse(list.Contains("basketball"));
            list.RemoveAt(0);
            Assert.AreEqual(list.Count, 0);
            Assert.IsFalse(list.Exists(x => x.Contains("e")));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToException1()
        {
            list.Add("century");
            string[] array = null;
            list.CopyTo(array, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToException2()
        {
            list.Add("support");
            string[] array = new string[1];
            list.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToException3()
        {
            list.Add("purpose");
            string[] array = new string[2];
            list.CopyTo(array, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindException1()
        {
            list.FindIndex(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FindException2()
        {
            list.Add("order");
            list.Add("supply");
            list.Add("ship");
            list.Find(x => x.Contains("a"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveException()
        {
            list.RemoveAt(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertException()
        {
            list.Insert(1, "university");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrueForAllException()
        {
            list.TrueForAll(null);
        }
    }
}
