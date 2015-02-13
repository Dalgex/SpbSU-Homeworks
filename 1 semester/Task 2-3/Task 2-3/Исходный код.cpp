#include <iostream>
#include <ctime>

using namespace std;

/* ���������� ���������
��� ������ ������� ��������� �� ����������� ����� ��������� ���������� ������� ������� �������� �� ��� �����
� ����� ������� ����� � ���������� ����������� ���������, � ���������� ������� ������������ �� ���� ������� � ������ �������
(���������� �� ������ ������� ��� ������ � ����, ������ � �������� ���������)
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
� ������� ������� searchMin � searchMax ������� ����������� � ������������ �������� �������,
����� ���������� �������� ����� �������� �������.
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

/* ���������� ���������
��� ������� arrayMainTwo[i] ����������� arraySecond[arrayMainTwo[i]] �� 1. ������ ���������� ������ �� ������� arraySecond �
��� ������� j � ������ arrayMainTwo �������� ����� j arraySecond[j] ���
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

/* ��������� �������� ������ arrayMain. ������� ��� ��������������� �������: arraySecond -
� ������� ���� �� �������������� ���������� ��������� � arrayMainTwo - ��� ��������
�������� ������� arrayMain �� �������� � ����, ����� ����� ������������� ������ ������ ����������� ���������.
*/

int main()
{
	setlocale(0, "");
	srand(time(nullptr));
	int const index = 100;
	int arrayMain[index] = { 0 };
	int arrayMainTwo[index] = { 0 };
	cout << "������ ��������� ��������� �������� ������� � ������� ����������� �� ��������. \n";
	cout << "������� ���������� ��������� � �������: ";
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
	cout << endl << "���������� ���������: ";
	for (int i = 0; i < number; i++)
	{
		cout << arrayMain[i] << " ";
	}
	cout << "\n";
	countingSort(number, arrayMainTwo);
	cout << "���������� ���������: ";
	for (int i = 0; i < number; i++)
	{
		cout << arrayMainTwo[i] << " ";
	}
	cout << "\n";
	return 0;
}

/* ��� ����� 6, ��������� ������: 14 9 4 5 9 2  ��� ���������� ��������: 2 4 5 9 9 14
��� ����� 9, ��������� ������: 11 2 4 10 14 4 3 3 7, ��� ���������� ������: 2 3 3 4 4 7 10 11 14
*/