using System;

namespace Task_1._2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите номер элемента последовательности Фибоначчи: ");
            int number = Int32.Parse(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("Некорректный ввод, т.к. число должно быть неотрицательным");
            }
            else
            {
                Console.WriteLine("{0}-й член последовательности Фибоначчи: {1}", number, fibonacci(number));
            }
        }

        static int fibonacci(int number)
        {
            int numTwoFib = 0; 
            int numOneFib = 1;
            int result = 0;

            while (number > 0)
            {
                result = numOneFib + numTwoFib;
                numOneFib = numTwoFib;
                numTwoFib = result;
                number--;
            }

            return numTwoFib;
        }
    }
}

/*
7-й член последовательности: 13
0-й член последовательности: 0
*/
