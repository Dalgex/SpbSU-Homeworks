using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._4
{
    class Program
    {
        static void Main()
        {
            PostfixCalculate postfixCalculate = new PostfixCalculate(new ArrayStack());
            //PostfixCalculate postfixCalculate = new PostfixCalculate(new Stack());
            Console.Write("Введите выражение в инфиксной форме: ");
            string expression = Console.ReadLine();
            char[] postfix = new char[50];

            if (!postfixCalculate.IsCorrectString(expression)) // если некорректное выражение...
            {
                return;
            }

            postfixCalculate.InfixToPostfix(expression, ref postfix);
            bool isValid = true; // создаем переменную, с помощью которой будем смотреть, есть ли деление на ноль или нет
            int i = 0;

            while (postfix[i] != '\0' && isValid)
            {
                postfixCalculate.AddNumericalDigit(postfix[i], ref isValid);
                i++;
            }

            if (isValid)
            {
                Console.WriteLine("Результат: {0}", postfixCalculate.TopValue());
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Деление на ноль");
            }   
        }
    }
}

/*
При вводе: 5+2*(1-6*(4-7))
Результат: 43

При вводе: 9 / ((5  - 3)* 2-1)
Результат: 3
 
При вводе: 8 - 4/ (3 -2 + (5-6))
Некорректный ввод. Деление на ноль
 
При вводе: 4 +6- *3
Некорректный ввод. Два оператора подряд

При вводе: 6*(3-2(4+6))
Некорректный ввод. После цифры идет открывающая скобка
 
При вводе: 7 - (6-)3
Некорректный ввод. После оператора идет закрывающая скобка
*/