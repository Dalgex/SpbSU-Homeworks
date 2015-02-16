using System;

namespace Task_1._6
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите размер массива: ");
            int size = Int32.Parse(Console.ReadLine());
            int[,] array = new int[size, size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = rand.Next(100);
                    Console.Write("{0:D2} ", array[i, j]); // {0:D2} – под целое число отводится 2 позиции для удобства отображения массива
                }

                Console.WriteLine();
            }

            int start = size / 2;  // начальная позиция (центр массива)
            int m = start;  // номер строки
            int n = start;  // номер столбца
            int step = 1;
            Console.Write("\n{0} ", array[m, n]); 
          
            /* Заметим, что наше движение по спирали реализуется следующим образом:
            1 вправо, 1 вниз; 2 влево, 2 вверх; 3 вправо, 3 вниз; 4 влево, 4 вверх...
            цикл работает до тех пор, пока не доходим до самой верхней строчки  
            */

            while (step < (size + 1) / 2)
            {
                while (Math.Abs(n - start) < step) // идем вправо
                {
                    n++;
                    Console.Write("{0} ", array[m, n]);
                }

                while (Math.Abs(m - start) < step) // идем вниз
                {
                    m++;
                    Console.Write("{0} ", array[m, n]);
                }

                n--;
                step++;

                while (Math.Abs(n - start) < step) // идем влево
                {
                    Console.Write("{0} ", array[m, n]);
                    n--;
                }

                m--;
                n++;

                while (Math.Abs(m - start) < step) // идем вверх
                {
                    Console.Write("{0} ", array[m, n]);
                    m--;
                }

                m++;
            }

            while (n < size - 1) // выводим оставшуюся верхнюю строчку
            {
                n++;
                Console.Write("{0} ", array[m, n]);
            }

            Console.WriteLine();
        }
    }
}
