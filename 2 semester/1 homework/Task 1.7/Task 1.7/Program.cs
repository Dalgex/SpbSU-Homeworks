using System;
using System.Collections.Generic;

namespace Task_1._7
{
    class Program
    {
        static void Swap(int[,] array, int index1, int index2)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int temp = array[i, index1];
                array[i, index1] = array[i, index2];
                array[i, index2] = temp;
            }
        }

        static void SelectionSort(int[,] array)
        {
            int min = 0;

            for (int i = 0; i < array.GetLength(1) - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < array.GetLength(1); j++)
                {
                    if (array[0, j] < array[0, min]) // если первый элемент j-ого столбца меньше минимального первого элемента другого столбца, то...
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(array, i, min);
                }
            }
        }

        static void Main()
        {
            Console.Write("Введите количество строк в массиве: ");
            int height = Int32.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов в массиве: ");
            int width = Int32.Parse(Console.ReadLine());
            int[,] array = new int[height, width];
            Random rand = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = rand.Next(100);
                    Console.Write("{0:D2} ", array[i, j]); // {0:D2} – под целое число отводится 2 позиции для удобства отображения массива
                }

                Console.WriteLine();
            }

            SelectionSort(array);
            Console.WriteLine("Матрица, отсортированная по первым элементам столбца:");

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0:D2} ", array[i, j]); 
                }

                Console.WriteLine();
            }
        }
    }
}

/*
Количество строк: 6
Количество столбцов: 4
69 29 78 66
56 49 86 35
39 27 85 27
54 84 73 16
39 72 99 09
61 39 39 39
 
29 66 69 78
49 35 56 86
27 27 39 85
84 16 54 73
72 09 39 99
39 39 61 39
*/