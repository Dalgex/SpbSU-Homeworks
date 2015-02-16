using System;

namespace Task_1._1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите целое неотрицательное число: ");
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Факториал числа {0} равен {1}", number, factorial(number));
        }

        static int factorial(int number)
        {
            if (number < 2)
            {
                return 1;
            }

            return number * factorial(number - 1);
        }
    }
}

/*
Факториал 10 равен 3628800
Факториал 0 равен 1
*/