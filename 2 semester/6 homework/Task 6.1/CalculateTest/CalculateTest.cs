using System;
using Task_6._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculateTest
{
    [TestClass]
    public class CalculateTest
    {
        private Calculator calculator;
        private bool isCorrect = true;

        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void ResultTest()
        {
            string str = calculator.AddNumber(String.Empty, "1", ref isCorrect);
            str = calculator.AddNumber(str, "2", ref isCorrect);
            str = calculator.AddOperator(str, "+", ref isCorrect);
            str = calculator.AddNumber(str, "3", ref isCorrect);
            Assert.AreEqual("12+3", str);
            str = calculator.AddFloatingPoint(str, ",", ref isCorrect);
            str = calculator.AddNumber(str, "6", ref isCorrect);
            str = calculator.AddOperator(str, "*", ref isCorrect);
            str = calculator.AddOpenBracket(str, "(", ref isCorrect);
            str = calculator.AddOperator(str, "-", ref isCorrect);
            Assert.AreEqual("12+3,6*(-", str);
            str = calculator.AddNumber(str, "7", ref isCorrect);
            str = calculator.AddOperator(str, "+", ref isCorrect);
            str = calculator.AddNumber(str, "5", ref isCorrect);
            str = calculator.AddCloseBracket(str, ")", ref isCorrect);
            Assert.AreEqual("12+3,6*(-7+5)", str);
            Assert.AreEqual((decimal)4.8, calculator.Result(str));
        }

        [TestMethod]
        public void AddNumberTest()
        {
            string str = calculator.AddNumber("0,24/", "5", ref isCorrect);
            Assert.AreEqual("0,24/5", str);
            
            str = calculator.AddNumber("0", "2", ref isCorrect);
            Assert.AreEqual("0", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;
            
            str = calculator.AddNumber("3756", "9", ref isCorrect);
            Assert.AreEqual("37569", str);
            
            str = calculator.AddNumber("74-0", "1", ref isCorrect);
            Assert.AreEqual("74-0", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddNumber("5,4*(", "8", ref isCorrect);
            Assert.AreEqual("5,4*(8", str);

            str = calculator.AddNumber("(-3+7,2)", "4", ref isCorrect);
            Assert.AreEqual("(-3+7,2)", str);
            Assert.AreEqual(isCorrect, false);
        }

        [TestMethod]
        public void AddOperatorTest()
        {
            string str = calculator.AddOperator(String.Empty, "*", ref isCorrect);
            Assert.AreEqual(String.Empty, str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;
            str = calculator.AddOperator(str, "-", ref isCorrect);
            Assert.AreEqual("-", str);

            str = calculator.AddOperator("5,942", "+", ref isCorrect);
            Assert.AreEqual("5,942+", str);

            str = calculator.AddOperator("-23/", "+", ref isCorrect);
            Assert.AreEqual("-23+", str);
            str = calculator.AddOperator(str, "*", ref isCorrect);
            Assert.AreEqual("-23*", str);

            str = calculator.AddOperator("592*(", "+", ref isCorrect);
            Assert.AreEqual("592*(", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;
            str = calculator.AddOperator(str, "-", ref isCorrect);
            Assert.AreEqual("592*(-", str);

            str = calculator.AddOperator("21-(4/3)", "/", ref isCorrect);
            Assert.AreEqual("21-(4/3)/", str);

            str = calculator.AddOperator("6-8,", "*", ref isCorrect);
            Assert.AreEqual("6-8,", str);
            Assert.AreEqual(isCorrect, false);
        }

        [TestMethod]
        public void AddOpenBracketTest()
        {
            string str = calculator.AddOpenBracket(String.Empty, "(", ref isCorrect);
            Assert.AreEqual("(", str);

            str = calculator.AddOpenBracket("34+1,", "(", ref isCorrect);
            Assert.AreEqual("34+1,", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddOpenBracket("-19/", "(", ref isCorrect);
            Assert.AreEqual("-19/(", str);

            str = calculator.AddOpenBracket("9,653+(", "(", ref isCorrect);
            Assert.AreEqual("9,653+((", str);

            str = calculator.AddOpenBracket("2*(-73)", "(", ref isCorrect);
            Assert.AreEqual("2*(-73)", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddOpenBracket("999+0,", "(", ref isCorrect);
            Assert.AreEqual("999+0,", str);
            Assert.AreEqual(isCorrect, false);
        }

        [TestMethod]
        public void AddCloseBracketTest()
        {
            string str = calculator.AddCloseBracket(String.Empty, ")", ref isCorrect);
            Assert.AreEqual(String.Empty, str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddCloseBracket("5/289", ")", ref isCorrect);
            Assert.AreEqual("5/289", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddCloseBracket("1,8*", ")", ref isCorrect);
            Assert.AreEqual("1,8*", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddOpenBracket("7,21+", "(", ref isCorrect);
            str = calculator.AddCloseBracket(str, ")", ref isCorrect);
            Assert.AreEqual("7,21+(0)", str);

            str = calculator.AddOpenBracket(String.Empty, "(", ref isCorrect);
            str = calculator.AddOpenBracket(str, "(", ref isCorrect);
            str = calculator.AddNumber(str, "6", ref isCorrect);
            str = calculator.AddCloseBracket(str, ")", ref isCorrect);
            str = calculator.AddCloseBracket(str, ")", ref isCorrect);
            Assert.AreEqual("((6))", str);
            str = calculator.AddCloseBracket(str, ")", ref isCorrect);
            Assert.AreEqual("((6))", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddCloseBracket("-17+261,", ")", ref isCorrect);
            Assert.AreEqual("-17+261,", str);
            Assert.AreEqual(isCorrect, false);
        }

        [TestMethod]
        public void AddFloatingPointTest()
        {
            string str = calculator.AddFloatingPoint(String.Empty, ",", ref isCorrect);
            Assert.AreEqual("0,", str);

            str = calculator.AddFloatingPoint("-58", ",", ref isCorrect);
            Assert.AreEqual("-58,", str);

            str = calculator.AddFloatingPoint("213+34,56", ",", ref isCorrect);
            Assert.AreEqual("213+34,56", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddFloatingPoint("5*0,", ",", ref isCorrect);
            Assert.AreEqual("5*0,", str);
            Assert.AreEqual(isCorrect, false);
            isCorrect = true;

            str = calculator.AddFloatingPoint("77-13/", ",", ref isCorrect);
            Assert.AreEqual("77-13/0,", str);

            str = calculator.AddFloatingPoint("432+(", ",", ref isCorrect);
            Assert.AreEqual("432+(0,", str);

            str = calculator.AddFloatingPoint("(-64+3)", ",", ref isCorrect);
            Assert.AreEqual("(-64+3)", str);
            Assert.AreEqual(isCorrect, false);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero()
        {
            string expression = "3,4-2/(5+2,5*(-2))";
            calculator.Result(expression);
        }
    }
}
