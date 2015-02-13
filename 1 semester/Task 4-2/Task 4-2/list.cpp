#include <iostream>
#include "list.h"

using namespace std;

void combSort(int array[], int number)
{
	int jump = number;

	while (jump > 1)
	{

		if (jump > 1)
		{
			jump /= 1.247;
		}

		for (int i = 0; i + jump < number; i++)
		{

			if (array[i + jump] < array[i])
			{
				swap(array[i], array[i + jump]);
			}

		}

	}
}

void mostFrequentElement(int number, int array[])
{
	int count = 1;
	int maximum = 1;

	for (int i = 0; i < number - 1; i++)
	{

		if (array[i] == array[i + 1])
		{
			count++;

			if (count > maximum)
			{
				maximum = count;
			}

		}

		else
		{
			count = 1;
		}

	}
	count = 1;
	int k = 0;
	int maxElement = 0;

	for (int i = 0; i < number - 1; i++)
	{

		if (array[i] == array[i + 1])
		{
			count++;

			if (count == maximum)
			{
				k++;
				maxElement = array[i];
			}

		}

		else
		{
			count = 1;
		}

	}

	if (k == 1)
	{
		cout << "Наиболее часто встречающийся элемент в массиве: " << maxElement;
	}

	else
	{
		cout << "Нет наиболее часто встречающегося элемента в массиве";
	}
}