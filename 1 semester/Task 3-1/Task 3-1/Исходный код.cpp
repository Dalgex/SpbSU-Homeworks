#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

/* ���������� ���������
������� �������� ��������� ��� ������ �������� �������.
����� �������� ��������� ������ ������� � ��������������� ������� ������� �� ��������� � ������ ���� ���������.
����� ����� �� ��������� ��������� ������� � ������ �� ���� ���������.
���� ������� ����������� �� ��� ���, ���� �� ����� ��������� ��� ��������. */

void insertionSort(int array[], int first, int last)
{
	for (int i = 1; i < last + 1; i++) // // last + 1 = number (���-�� ��������� � �������)
	{
		for (int j = i; array[j] < array[j - 1] && j > 0; j--)
		{
			swap(array[j], array[j - 1]);
		}
	}
}

/* ������� ����������
�� ������� ���������� ��������� ������� ������� array[centre].
�������� ��� ��������� �������� � ������� � ����������� �� � ������� ���,
����� ������� ������ �� ��� ����������� �������, ��������� ���� �� ������ � �������� ��������, ������� � �������.
��� ���� �������� ��������� ���������� �� �� ������������������ ��������, ���� ����� ������� ������ �������.
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

/* ��������� ���������� ��������� � �������. ����� ��������� �������� ������� ���������� ������� � ������� ������
���� ������ ������� ������ 10, �� ��������� ���������� ���������, ����� - ������� ����������
*/

int main()
{
	setlocale(0, "");
	srand(time(nullptr));
	int const index = 100;
	int array[index] = { 0 };
	int number = 0;
	cout << "������� ���������� ��������� � �������: ";
	cin >> number;
	for (int i = 0; i < number; i++)
	{
		array[i] = rand() % 20;
		cout << array[i] << " ";
	}
	quickSort(array, 0, number - 1);
	cout << endl << "���������: ";
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << endl;
	return 0;
}

/* ��� ����� 9, ��������� ������ ��������: 3 4 4 17 7 3 15 15 9, ���������: 3 3 4 4 7 9 15 15 17
��� ����� 10, ��������� ������ ��������: 11 3 13 1 3 2 5 18 6 0, ���������: 0 1 2 3 3 5 6 11 13 18
*/