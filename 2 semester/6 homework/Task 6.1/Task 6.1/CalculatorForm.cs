using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_6._1
{
    /// <summary>
    /// Предоставляет калькулятор с пользовательским интерфейсом
    /// </summary>
    public partial class CalculatorForm : Form
    {
        private Calculator calculator;

        public CalculatorForm()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        /// <summary>
        /// Происходит при нажатии цифры
        /// </summary>
        private void OnDigitClick(string symbol)
        {
            bool isCorrect = true;
            label1.Text = calculator.AddNumber(label1.Text, symbol, ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        /// <summary>
        /// Происходит при нажатии арифметического знака
        /// </summary>
        private void OnOperatorClick(string symbol)
        {
            bool isCorrect = true;
            label1.Text = calculator.AddOperator(label1.Text, symbol, ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            OnDigitClick("1");
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            OnDigitClick("2");
        }

        private void OnButton3Click(object sender, EventArgs e)
        {
            OnDigitClick("3");
        }

        private void OnButton4Click(object sender, EventArgs e)
        {
            OnDigitClick("4");
        }

        private void OnButton5Click(object sender, EventArgs e)
        {
            OnDigitClick("5");
        }

        private void OnButton6Click(object sender, EventArgs e)
        {
            OnDigitClick("6");
        }

        private void OnButton7Click(object sender, EventArgs e)
        {
            OnDigitClick("7");
        }

        private void OnButton8Click(object sender, EventArgs e)
        {
            OnDigitClick("8");
        }

        private void OnButton9Click(object sender, EventArgs e)
        {
            OnDigitClick("9");
        }

        private void OnButton10Click(object sender, EventArgs e)
        {
            OnDigitClick("0");
        }

        private void OnButton11Click(object sender, EventArgs e)
        {
            OnOperatorClick("+");
        }

        private void OnButton12Click(object sender, EventArgs e)
        {
            OnOperatorClick("-");
        }

        private void OnButton13Click(object sender, EventArgs e)
        {
            OnOperatorClick("*");
        }

        private void OnButton14Click(object sender, EventArgs e)
        {
            OnOperatorClick("/");
        }

        private void OnButton15Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            label1.Text = calculator.AddFloatingPoint(label1.Text, ",", ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnButton16Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label1.Text))
            {
                return;
            }

            char[] postfix = new char[100];

            if (!calculator.IsCorrectString(label1.Text))
            {
                label2.Text = "Некорректный ввод";
                return;
            }

            calculator.InfixToPostfix(label1.Text, ref postfix);
            bool isValid = true; // создаем переменную, с помощью которой будем смотреть, есть ли деление на ноль или нет

            calculator.AddNumericalDigit(postfix, ref isValid);

            if (isValid)
            {
                label1.Text = Convert.ToString(calculator.TopValue());
                label2.Text = string.Empty;
            }
            else
            {
                label1.Text = string.Empty;
                label2.Text = "Деление на ноль";
            }
        }

        private void OnButton17Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            label1.Text = calculator.AddOpenBracket(label1.Text, "(", ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnButton18Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            label1.Text = calculator.AddCloseBracket(label1.Text, ")", ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnButton19Click(object sender, EventArgs e)
        {
            label1.Text = calculator.CleanLine();
            label2.Text = string.Empty;
        }
    }
}
