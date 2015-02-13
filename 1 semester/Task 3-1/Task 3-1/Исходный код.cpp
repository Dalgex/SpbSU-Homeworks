#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

/* Сортировка вставками
Сначала алгоритм сортирует два первых элемента массива.
Затем алгоритм вставляет третий элемент в соответствующую порядку позицию по отношению к первым двум элементам.
После этого он вставляет четвертый элемент в список из трех элементов.
Этот процесс повторяется до тех пор, пока не будут вставлены все элементы. */

void insertionSort(int array[], int first, int last)
{
	for (int i = 1; i < last + 1; i++) // // last + 1 = number (кол-во элементов в массиве)
	{
		for (int j = i; array[j] < array[j - 1] && j > 0; j--)
		{
			swap(array[j], array[j - 1]);
		}
	}
}

/* Быстрая сортировка
Из массива выбирается некоторый опорный элемент array[centre].
Сравнить все остальные элементы с опорным и переставить их в массиве так,
чтобы разбить массив на два непрерывных отрезка, следующие друг за другом — «меньшие опорного», «равные и большие».
Для этих отрезков выполнить рекурсивно ту же последовательность операций, если длина отрезка больше единицы.
*/

void quickSort(int array[], int first, int last)
{
	if (last + 1 < 10)
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
			if (i <= j)
			{
				swap(array[i], array[j]);
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

/* Считываем количество элементов в массиве. Затем заполянем элементы массива случайными числами и выводим массив
Если размер массива меньше 10, то реализуем сортировку вставками, иначе - быструю сортировку
*/

int main()
{
	setlocale(0, "");
	srand(time(nullptr));
	int const index = 100;
	int array[index] = { 0 };
	int number = 0;
	cout << "Введите количество элементов в массиве: ";
	cin >> number;
	for (int i = 0; i < number; i++)
	{
		array[i] = rand() % 20;
		cout << array[i] << " ";
	}
	quickSort(array, 0, number - 1);
	cout << endl << "Результат: ";
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << endl;
	return 0;
}

/* При вводе 9, программа вывела элементы: 3 4 4 17 7 3 15 15 9, результат: 3 3 4 4 7 9 15 15 17
При вводе 10, программа вывела элементы: 11 3 13 1 3 2 5 18 6 0, результат: 0 1 2 3 3 5 6 11 13 18
*/