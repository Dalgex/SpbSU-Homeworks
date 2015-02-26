using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._4
{
    class PostfixCalculate
    {
        private IStack stack;

        public PostfixCalculate(IStack selectedStack)
        {
            stack = selectedStack;
        }

        /// <summary>
        ///  Проверка, является ли данный символ цифрой
        /// </summary>
        private bool IsDigit(char symbol)
        {
            return (symbol >= '0') && (symbol <= '9');
        }

        /// <summary>
        ///  Проверка, является ли данный символ арифметическим знаком
        /// </summary>
        private bool IsOperator(char symbol)
        {
            return (symbol == '+') || (symbol == '-') || (symbol == '*') || (symbol == '/');
        }

        /// <summary>
        ///  Проверка, является ли данный символ открывающей скобкой
        /// </summary>
        private bool IsOpenBracket(char symbol)
        {
            return symbol == '(';
        }

        /// <summary>
        ///  Проверка, является ли данный символ закрывающей скобкой
        /// </summary>
        private bool IsCloseBracket(char symbol)
        {
            return symbol == ')';
        }

        /// <summary>
        ///  Проверка, является ли данный символ круглой скобкой
        /// </summary>
        private bool IsBracket(char symbol)
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

            return ((char) stack.Top()) == '(';
        }

        /// <summary>
        ///  Проверка, является ли данный символ пробелом
        /// </summary>
        private bool IsSpace(char symbol)
        {
            return symbol == ' ';
        }

        /// <summary>
        ///  Проверяем приоритет операторов
        /// </summary>
        private int CheckPriority(char symbol)
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
            int j = 0;

            for (int i = 0; i < infix.Length; i++)
            {
                if (IsDigit(infix[i]))
                {
                    postfix[j++] = infix[i];
                }
                else
                {
                    if ((IsSpace(infix[i])))
                    {
                        continue;
                    }

                    if (IsOperator(infix[i]))
                    {
                        if (stack.IsEmpty())
                        {
                            stack.Push(infix[i]);
                        }
                        else
                        {
                            while (!stack.IsEmpty() && CheckPriority(infix[i]) <= CheckPriority((char) stack.Top())) 
                            {
                                postfix[j++] = (char)stack.Pop(); 
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
                                postfix[j++] = (char) stack.Pop();
                            }

                            stack.Pop();
                        }
                    }
                }
            }

            while (!stack.IsEmpty())
            {
                postfix[j++] = (char) stack.Pop();
            }
        }

        /// <summary>
        /// Проверка на корректность введенного выражения
        /// </summary>
        public bool IsCorrectString(string expression)
        {
            expression = expression.Replace(" ", string.Empty); // удаляем все пробелы

            if (!IsDigit(expression[0]) && !IsOpenBracket(expression[0])) // если первый символ не цифра и не скобка
            {
                Console.WriteLine("Некорректный ввод. Первый символ выражения не являяется цифрой или открывающей скобкой");
                return false;
            }

            int lastIndex = expression.Length; // индекс последнего элемента

            if (!IsDigit(expression[lastIndex - 1]) && !IsCloseBracket(expression[lastIndex - 1]))
            {
                Console.WriteLine("Некорректный ввод. Последний символ выражения не являяется цифрой или закрывающей скобкой");
                return false;
            }

            if (IsOpenBracket(expression[0]))
            {
                stack.Push(expression[0]);
            }

            for (int i = 1; i < expression.Length; i++)
            {
                if (!IsBracket(expression[i]) && !IsOperator(expression[i]) && !IsDigit(expression[i])) 
                {
                    Console.WriteLine("Некорректный ввод. Найден символ, не являющийся допустимым: не цифра, не оператор, не круглая скобка");
                    return false;
                }

                if (IsOpenBracket(expression[i]))
                {
                    stack.Push(expression[i]);
                }

                if (IsCloseBracket(expression[i]))
                {
                    if (stack.IsEmpty()) 
                    {
                        Console.WriteLine("Некорректный ввод. Закрывающая скобка стоит раньше открывающей");
                        return false;
                    }

                    stack.Pop(); 
                }

                if (IsOpenBracket(expression[i - 1]) && IsOperator(expression[i]))
                {
                    Console.WriteLine("Некорректный ввод. Оператор стоит после открыващей скобки");
                    return false;
                }

                if (IsDigit(expression[i - 1]) && IsOpenBracket(expression[i]))
                {
                    Console.WriteLine("Некорректный ввод. После цифры идет открывающая скобка");
                    return false;
                }

                if (IsOpenBracket(expression[i - 1]) && IsCloseBracket(expression[i]))
                {
                    Console.WriteLine("Некорректный ввод. Между открывающей скобкой и закрывающей ничего не стоит");
                    return false;
                }

                if (IsOperator(expression[i - 1]) && IsCloseBracket(expression[i])) 
                {
                    Console.WriteLine("Некорректный ввод. После оператора идет закрывающая скобка");
                    return false;
                }

                if (IsCloseBracket(expression[i - 1]) && IsDigit(expression[i])) 
                {
                    Console.WriteLine("Некорректный ввод. Идет цифра после закрывающей скобки");
                    return false;
                }

                if (IsDigit(expression[i - 1]) && IsDigit(expression[i])) 
                {
                    Console.WriteLine("Некорректный ввод. Две цифры подряд");
                    return false;
                }

                if (IsOperator(expression[i - 1]) && IsOperator(expression[i])) // два оператора подряд
                {
                    Console.WriteLine("Некорректный ввод. Два оператора подряд");
                    return false;
                }
            }

            return stack.IsEmpty();
        }

        /// <summary>
        ///  Вычисляем значение
        /// </summary>
        public void calculateValues(char operation, ref bool isValid)
        {
            int value2 = (int) stack.Pop();
            int value1 = (int) stack.Pop();

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
        public void AddNumericalDigit(char symbol, ref bool isValid)
        {
            if (IsDigit(symbol))
            {
                stack.Push(symbol - '0');
            }
            else
            {
                if (symbol == ' ')
                {
                    return;
                }

                calculateValues(symbol, ref isValid);
            }
        }

        /// <summary>
        ///  Возвращаем значение верхнего элемента
        /// </summary>
        /// <returns></returns>
        public int TopValue()
        {
            return (int) stack.Top();
        }
    }
}
