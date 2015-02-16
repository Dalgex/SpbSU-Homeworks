using System;

namespace Task_1._3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество элементов массива: ");
            int number = Int32.Parse(Console.ReadLine());
            int[] array = new int[number];
            Random rand = new Random();
            Console.Write("Элементы массива: ");

            for (int i = 0; i < number; i++)
            {
                array[i] = rand.Next(-20, 30) % 20;
                Console.Write("{0} ", array[i]);
            }

            Console.Write("\nОтсортированный массив: ");
            quickSort(array, 0, number - 1);

            for (int i = 0; i < number; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }

        static void swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void insertionSort(int[] array, int first, int last)
        {
            for (int i = first; i <= last; i++) 
	        {
		        for (int j = i; j > 0 && array[j] < array[j - 1]; j--)
		        {
			        swap(array, j, j - 1);
		        }
	        }
        }

        static void quickSort(int[] array, int first, int last)
        {
            if (last - first < 10)
            {
                insertionSort(array, first, last);
            }
            else
            {
                int i = first;
                int j = last;
                int centre = (first + last) / 2;
                int strongPoint = array[centre];
               
                while (i < j)
                {
                    while (array[i] < strongPoint)
                    {
                        i++;
                    }
                    
                    while (array[j] > strongPoint)
                    {
                        j--;
                    }
                   
                    if (i < j)
                    {
                        swap(array, i, j);
                        i++;
                        j--;
                    }
                }

                if (i < last)
                {
                    quickSort(array, i, last);
                }

                if (first < j)
                {
                    quickSort(array, first, j);
                }
            }
        }
    }
}

/*
Количество элементов в массиве: 13
Числа на входе: -14 -18 -17 -12 3 9 0 13 3 - 19 7 9
Отсортированный массив: -19 -18 -17 -14 -12 0 0 3 3 7 9 9 13

Количество элементов в массиве: 22
Числа на входе: 19 -12 18 11 9 3 18 4 14 -5 14 3 2 -17 0 -3 -16 6 -3 -10 15 19
Отсортированный массив: -17 -16 -12 -10 -5 -3 -3 0 2 3 3 4 6 9 11 14 14 15 18 18 19 19
*/
