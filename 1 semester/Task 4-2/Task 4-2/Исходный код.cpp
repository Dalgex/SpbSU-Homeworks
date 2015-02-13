#include <iostream>
#include "list.h"
#include <fstream>

using namespace std;

int main()
{
	setlocale(0, "");
	ifstream file("input.txt");

	if (!file.is_open())
	{
		cout << "File not found!" << endl;
		return 1;
	}

	int sizeOfArray = 10;
	int *array = new int[sizeOfArray];
	int count = 0;

	while (!file.eof())
	{
		int number = 0;
		file >> number;
		cout << number << " ";

		if (count == sizeOfArray)
		{
			sizeOfArray += 10;
			int *newArray = new int[sizeOfArray];

			for (int i = 0; i < count; i++)
			{
				newArray[i] = array[i];
			}

			delete[] array;
			array = newArray;
		}

		array[count++] = number; // равносильно: array[count] = number; count++;
	}

	file.close();
	cout << endl;

	combSort(array, count);
	mostFrequentElement(count, array);

	cout << endl;
	delete[] array;
	return 0;
}