using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6._1
{
    /// <summary>
    /// Класс калькулятор для выполнения арифметических расчетов
    /// </summary>
    public class Calculator
    {
        private Stack stack;

        public Calculator()
        {
            stack = new Stack();
        }

        /// <summary>
        ///  Проверка, является ли данный символ цифрой
        /// </summary>
        private static bool IsDigit(char symbol)
        {
            return (symbol >= '0') && (symbol <= '9');
        }

        /// <summary>
        ///  Проверка, является ли данный символ арифметическим знаком
        /// </summary>
        private static bool IsOperator(char symbol)
        {
            return (symbol == '+') || (symbol == '-') || (symbol == '*') || (symbol == '/');
        }

        /// <summary>
        ///  Проверка, является ли данный символ открывающей скобкой
        /// </summary>
        private static bool IsOpenBracket(char symbol)
        {
            return symbol == '(';
        }

        /// <summary>
        ///  Проверка, является ли данный символ закрывающей скобкой
        /// </summary>
        private static bool IsCloseBracket(char symbol)
        {
            return symbol == ')';
        }

        /// <summary>
        /// Проверка, является ли данный символ минусом
        /// </summary>
        private static bool IsMinus(char symbol)
        {
            return symbol == '-';
        }

        /// <summary>
        /// Проверка, является ли данный символ плавающей запятой
        /// </summary>
        private static bool IsFloatingPoint(char symbol)
        {
            return symbol == ',';
        }

        /// <summary>
        ///  Проверка, является ли данный символ круглой скобкой
        /// </summary>
        private static bool IsBracket(char symbol)
        {
            return symbol == '(' || symbol == ')';
        }

        /// <summary>
        ///  Проверка, является ли символ последнего элемента стека открывающей скобкой
        /// </summary>
        private bool IsOpenBracketStack()
        {
            if (stack.IsEmpty())
            {
                return false;
            }

            return ((char)stack.Top()) == '(';
        }

        /// <summary>
        ///  Проверка, является ли данный символ пробелом
        /// </summary>
        private static bool IsSpace(char symbol)
        {
            return symbol == ' ';
        }

        /// <summary>
        /// Проверка, является ли данный символ нулем
        /// </summary>
        private static bool IsZero(char symbol)
        {
            return symbol == '0';
        }
        
        /// <summary>
        /// Возвращает пустую строку, если выражение корректно, в противном случае возвращает "Некорректный ввод"
        /// </summary>
        public string ReturnString(bool isCorrect)
        {
            if (isCorrect)
            {
                return string.Empty;
            }

            return "Некорректный ввод";
        }

        /// <summary>
        /// Добавление числа в окно вывода
        /// </summary>
        public string AddNumber(string expression, string number, ref bool isCorrect)
        {
            if (String.IsNullOrEmpty(expression))
            {
                return expression + number;
            }

            int index = expression.Length - 1;

            if (IsCloseBracket(expression[index]))
            {
                isCorrect = false;
                return expression;
            }

            // Если предыдущий нуль, то проверяем дальше:
            // если он является первым символом выражения - ошибка, т.к. число, например, 02 - некорректно
            // если перед нулем идет не запятая и не другая цифра - тоже ошибка, т.к. наше число начинается с нуля, а после него идет цифра
            if (IsZero(expression[index]))
            {
                if (index == 0 || !IsFloatingPoint(expression[index - 1]) && !IsDigit(expression[index - 1]))
                {
                    isCorrect = false;
                    return expression;
                }
            }

            return expression + number;
        }

        /// <summary>
        /// Добавление оператора в окно вывода
        /// </summary>
        public string AddOperator(string expression, string operation, ref bool isCorrect)
        {
            int index = expression.Length - 1;

            // Если строка пустая или идет открывающая скобка, то необходима доп. проверка:
            // знак минус может идти в начале выражения или после открывающей скобки,
            // остальные же операторы не могут
            // Еще, конечно, "+" может идти, но его не принято писать в таких случаях
            if (String.IsNullOrEmpty(expression) || IsOpenBracket(expression[index]))
            {
                if (operation.Equals("-"))
                {
                    return expression + operation;
                }

                isCorrect = false;
                return expression;
            }


            if (IsFloatingPoint(expression[index]))
            {
                isCorrect = false;
                return expression;
            }

            // Если оператор, то проверяем, какой именно
            // Если не минус, то меняем один оператор на другой
            // Если же минус, то нужно понять, какой символ идет перед минусом
            // Если перед минусом стоит открывающая скобка или минус вовсе является первым символом выражения,
            // то ошибка, этот случай разбирался выше
            // Если же перед минусом идут другие символы (число или закрывающая собка), то все хорошо,
            // меняем один оператор на другой
            if (IsOperator(expression[index]))
            {
                if (IsMinus(expression[index]))
                {
                    if (index == 0 || IsOpenBracket(expression[index - 1]))
                    {
                        isCorrect = false;
                        return expression;
                    }
                }

                string newstr = expression.Substring(0, index);
                return newstr + operation;
            }

            return expression + operation;
        }

        /// <summary>
        /// Добавление плавающей запятой в окно вывода
        /// </summary>
        public string AddFloatingPoint(string expression, string symbol, ref bool isCorrect)
        {
            int index = expression.Length - 1;

            // Будем считать, как в виндовом калькуляторе:
            // если после оператора или открывающей скобки нажимается кнопка с запятой, 
            // то программа перед запятой ставит 0, т.е. получаем какое-то число, по модулю меньшее единицы
            if (String.IsNullOrEmpty(expression) || IsOperator(expression[index]) || IsOpenBracket(expression[index]))
            {
                return expression + "0" + symbol;
            }

            // Проверяем, не было ли ранее в числе плавающей запятой
            // Для этого, пока предыдущий символ цифра, передвигаемся на один символ влево
            // И так, пока не закончатся идти цифры или не достигнем начала строки
            // Но предыдущий символ может и вовсе не быть цифрой, 
            // тогда в цикл не заходим, сразу же переходим к следующему условию
            while (index >= 0 && IsDigit(expression[index]))
            {
                index--;
            }

            // Если index < 0, значит, наша строка начиналась с числа и всё корректно, других символов встречено не было
            // Если же index >= 0, то делаем доп проверку:
            // если наткнулись на запятую или на закрывающую скобку, ошибка,
            // т.к. число не может состоять из двух плавающих запятых
            // В каком случае мы можем наткнуться на закрывающую скобку: 
            // если шла закрывающая скобка, а потом число, то эту ошибку выдаст AddNumber
            // Здесь же могла произойти такая ситуация: шло выражение, потом закрывающая скобка,
            // а сразу же после нее плавающая запятая - некорректное выражение
            if (index >= 0)
            {
                if (IsFloatingPoint(expression[index]) || IsCloseBracket(expression[index]))
                {
                    isCorrect = false;
                    return expression;
                }
            }

            return expression + symbol;
        }

        /// <summary>
        /// Добавление открывающей скобки в окно вывода
        /// </summary>
        public string AddOpenBracket(string expression, string bracket, ref bool isCorrect)
        {
            int index = expression.Length - 1;

            if (String.IsNullOrEmpty(expression) || IsOperator(expression[index]) || IsOpenBracket(expression[index]))
            {
                stack.Push(bracket); // добавляем в стек открывающую скобку, чтобы проверять баланс скобок
                return expression + bracket;
            }

            isCorrect = false;
            return expression;
        }

        /// <summary>
        /// Добавление закрывающей скобки в окно вывода
        /// </summary>
        public string AddCloseBracket(string expression, string bracket, ref bool isCorrect)
        {
            // если стек пуст, значит, баланс скобок нарушен
            if (String.IsNullOrEmpty(expression) || stack.IsEmpty())
            {
                isCorrect = false;
                return expression;
            }

            int index = expression.Length - 1;

            if (IsDigit(expression[index]) || IsCloseBracket(expression[index]))
            {
                stack.Pop();
                return expression + bracket;
            }

            // будем считать, что если после открывающей скобки идет закрывающая, то между ними ставится 0
            if (IsOpenBracket(expression[index]))
            {
                stack.Pop();
                return expression + "0" + bracket;
            }

            isCorrect = false;
            return expression;
        }

        /// <summary>
        /// Очистка окна вывода
        /// </summary>
        public string CleanLine()
        {
            stack.Clear();
            return string.Empty;
        }

        /// <summary>
        ///  Проверяем приоритет операторов
        /// </summary>
        private static int CheckPriority(char symbol)
        {
            switch (symbol)
            {
                case '*':
                case '/':
                {
                    return 2;
                }

                case '+':
                case '-':
                {
                    return 1;
                }
            }

            return 0;
        }

        /// <summary>
        ///  Перевод из инфиксной записи в постфиксную
        /// </summary>
        public void InfixToPostfix(string infix, ref char[] postfix)
        {
            int i = 0;
            int j = 0;

            // Если первый знак минус, добавляем его в выходную строку
            if (IsMinus(infix[i]))
            {
                postfix[j++] = infix[i++];
            }

            while (i < infix.Length)
            {
                if (IsDigit(infix[i]))
                {
                    while (i < infix.Length && (IsDigit(infix[i]) || IsFloatingPoint(infix[i])))
                    {
                        postfix[j++] = infix[i++];
                    }

                    postfix[j++] = ' ';
                    // После каждого числа и оператора будем ставить пробел, 
                    // чтобы корректно определить, какое выражение было введено
                    // Например, при вводе: 25+6 программа выведет: 25 6 +
                    // Сразу понятно, какие числа складываем. Без пробелов это выглядело бы так: 256+
                }
                else
                {
                    if (IsOperator(infix[i]))
                    {
                        if (stack.IsEmpty())
                        {
                            stack.Push(infix[i]);
                        }
                        else if (IsMinus(infix[i]) && IsOpenBracket(infix[i - 1]))
                        {
                            postfix[j++] = infix[i];
                        }
                        else
                        {
                            while (!stack.IsEmpty() && CheckPriority(infix[i]) <= CheckPriority((char)stack.Top()))
                            {
                                postfix[j++] = (char)stack.Pop();
                                postfix[j++] = ' ';
                            }

                            stack.Push(infix[i]);
                        }
                    }
                    else
                    {
                        if (IsOpenBracket(infix[i]))
                        {
                            stack.Push(infix[i]);
                        }
                        else
                        {
                            while (!IsOpenBracketStack())
                            {
                                postfix[j++] = (char)stack.Pop();
                                postfix[j++] = ' ';
                            }

                            stack.Pop();
                        }
                    }

                    i++;
                }
            }

            while (!stack.IsEmpty())
            {
                postfix[j++] = (char)stack.Pop();
                postfix[j++] = ' ';
            }
        }

        /// <summary>
        /// Проверка на корректность введенного выражения
        /// </summary>
        public bool IsCorrectString(string expression)
        {
            // Проверяем только последний символ, т.к. если бы ранее встретились ошибки, программа бы нам об этом сказала
            int index = expression.Length - 1;

            if (!IsDigit(expression[index]) && !IsCloseBracket(expression[index]))
            {
                return false;
            }

            return stack.IsEmpty();
        }

        /// <summary>
        ///  Вычисляем значение
        /// </summary>
        public void CalculateValues(char operation, ref bool isValid)
        {
            decimal value2 = (decimal)stack.Pop();
            decimal value1 = (decimal)stack.Pop();

            switch (operation)
            {
                case '+':
                {
                    stack.Push(value1 + value2);
                    break;
                }

                case '-':
                {
                    stack.Push(value1 - value2);
                    break;
                }

                case '*':
                {
                    stack.Push(value1 * value2);
                    break;
                }

                case '/':
                {
                    if (value2 == 0)
                    {
                        isValid = false;
                        return;
                    }

                    stack.Push(value1 / value2);
                    break;
                }
            }
        }

        /// <summary>
        ///  Если символ является цифрой, добавляем его в стек, если оператор - вычисляем значение
        /// </summary>
        public void AddNumericalDigit(char[] postfix, ref bool isValid)
        {
            int i = 0;
            Console.WriteLine(postfix);

            while (postfix[i] != '\0' && isValid)
            {
                string line = "";

                if (IsDigit(postfix[i]) || postfix[i] == '-' && IsDigit(postfix[i + 1]))
                {
                    while (postfix[i] != ' ')
                    {
                        line = line + postfix[i++].ToString();
                    }

                    stack.Push(Convert.ToDecimal(line));
                }
                else
                {
                    if (postfix[i] != ' ')
                    {
                        CalculateValues(postfix[i], ref isValid);
                    }
                }

                i++;
            }
        }

        /// <summary>
        /// Метод для тестов, вычисляет выражение
        /// </summary>
        public decimal Result(string expression)
        {
            char[] postfix = new char[100];
            InfixToPostfix(expression, ref postfix);
            bool isValid = true; // создаем переменную, с помощью которой будем смотреть, есть ли деление на ноль или нет

            AddNumericalDigit(postfix, ref isValid);

            if (isValid)
            {
                return TopValue();
            }
            else
            {
                throw new DivideByZeroException();
            }
        }

        /// <summary>
        ///  Возвращаем значение верхнего элемента
        /// </summary>
        public decimal TopValue()
        {
            return (decimal)stack.Pop();
        }
    }
}
