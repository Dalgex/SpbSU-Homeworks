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
        private static bool isResultClick;

        public CalculatorForm()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        /// <summary>
        /// Проверка, была ли нажата кнопка "=". Если да, то очищает строку ввода
        /// </summary>
        private void CheckResultClick()
        {
            if (isResultClick)
            {
                label1.Text = string.Empty;
                isResultClick = false;
            }
        }

        private void OnDigitClick(object sender, EventArgs e)
        {
            CheckResultClick();
            var button = (Button)sender;
            bool isCorrect = true;
            label1.Text = calculator.AddNumber(label1.Text, button.Text, ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnOperatorClick(object sender, EventArgs e)
        {
            isResultClick = false;
            var button = (Button)sender;
            bool isCorrect = true;
            label1.Text = calculator.AddOperator(label1.Text, button.Text, ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnFloatingPointClick(object sender, EventArgs e)
        {
            CheckResultClick();
            bool isCorrect = true;
            label1.Text = calculator.AddFloatingPoint(label1.Text, ",", ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnResultClick(object sender, EventArgs e)
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
                isResultClick = true;
                label1.Text = Convert.ToString(calculator.TopValue());
                label2.Text = string.Empty;
            }
            else
            {
                label1.Text = calculator.CleanLine();
                label2.Text = "Деление на ноль";
            }
        }

        private void OnOpenBracketClick(object sender, EventArgs e)
        {
            CheckResultClick();
            bool isCorrect = true;
            label1.Text = calculator.AddOpenBracket(label1.Text, "(", ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnCloseBracketClick(object sender, EventArgs e)
        {
            bool isCorrect = true;
            label1.Text = calculator.AddCloseBracket(label1.Text, ")", ref isCorrect);
            label2.Text = calculator.ReturnString(isCorrect);
        }

        private void OnDeletionClick(object sender, EventArgs e)
        {
            isResultClick = false;
            label1.Text = calculator.CleanLine();
            label2.Text = string.Empty;
        }
    }
}
