#include <iostream>
#include <ctime>

using namespace std;

/* Сортировка пузырьком
При каждом проходе алгоритма по внутреннему циклу очередной наибольший элемент массива ставится на своё место
в конце массива рядом с предыдущим «наибольшим элементом», а наименьший элемент перемещается на одну позицию к началу массива
(«всплывает» до нужной позиции как пузырёк в воде, отсюда и название алгоритма)
*/

void bubbleSort(int arrayMain[], int number)
{
	for (int i = 0; i < number - 1; i++)
	{
		for (int j = 0; j < number - i - 1; j++)
		{
			if (arrayMain[j] > arrayMain[j + 1])
			{
				swap(arrayMain[j], arrayMain[j + 1]);
			}
		}
	}
}

/*
С помощью функций searchMin и searchMax находим минимальный и максимальный элементы массива,
чтобы определить диапазон чисел входного массива.
*/

int searchMin(int number, int arrayMainTwo[])
{
	int const firstIndex = 0;
	int minimum = arrayMainTwo[firstIndex];
	for (int i = 0; i < number - 1; i++)
	{
		if (minimum > arrayMainTwo[i + 1])
		{
			minimum = arrayMainTwo[i + 1];
		}
	}
	return minimum;
}

int searchMax(int number, int arrayMainTwo[])
{
	int const firstIndex = 0;
	int maximum = arrayMainTwo[firstIndex];
	for (int i = 0; i < number - 1; i++)
	{
		if (maximum < arrayMainTwo[i + 1])
		{
			maximum = arrayMainTwo[i + 1];
		}
	}
	return maximum;
}

/* Сортировка подсчетом
Для каждого arrayMainTwo[i] увеличиваем arraySecond[arrayMainTwo[i]] на 1. Теперь достаточно пройти по массиву arraySecond и
для каждого j в массив arrayMainTwo записать число j arraySecond[j] раз
*/

void countingSort(int number, int arrayMainTwo[])
{
	int minimum = searchMin(number, arrayMainTwo);
	int maximum = searchMax(number, arrayMainTwo);
	int const range = 1000;
	int arraySecond[range] = { 0 };
	for (int i = 0; i < number; i++)
	{
		arraySecond[arrayMainTwo[i] - minimum]++;
	}
	int count = 0;
	for (int j = 0; j < maximum - minimum + 1; j++)
	{
		for (int i = 0; i < arraySecond[j]; i++)
		{
			arrayMainTwo[count] = j + minimum;
			count++;
		}
	}
}

/* Считываем основной массив arrayMain. Создаем два вспомогательных массива: arraySecond -
с помощью него мы организовываем сортировку подсчетом и arrayMainTwo - все элементы
входного массива arrayMain мы копируем в него, чтобы потом отсортировать данный массив сортировкой подсчетом.
*/

int main()
{
	setlocale(0, "");
	srand(time(nullptr));
	int const index = 100;
	int arrayMain[index] = { 0 };
	int arrayMainTwo[index] = { 0 };
	cout << "Данная программа сортирует элементы массива в порядке возрастания их значений. \n";
	cout << "Введите количество элементов в массиве: ";
	int number = 0;
	cin >> number;
	for (int i = 0; i < number; i++)
	{
		arrayMain[i] = rand() % 20;
		cout << arrayMain[i] << " ";
	}
	for (int i = 0; i < number; i++)
	{
		arrayMainTwo[i] = arrayMain[i];
	}
	bubbleSort(arrayMain, number);
	cout << endl << "Сортировка пузырьком: ";
	for (int i = 0; i < number; i++)
	{
		cout << arrayMain[i] << " ";
	}
	cout << "\n";
	countingSort(number, arrayMainTwo);
	cout << "Сортировка подсчетом: ";
	for (int i = 0; i < number; i++)
	{
		cout << arrayMainTwo[i] << " ";
	}
	cout << "\n";
	return 0;
}

/* При вводе 6, программа вывела: 14 9 4 5 9 2  обе сортировки показали: 2 4 5 9 9 14
При вводе 9, программа вывела: 11 2 4 10 14 4 3 3 7, обе сортировки вывели: 2 3 3 4 4 7 10 11 14
*/